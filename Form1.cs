using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace computer_graphic_labs
{
    public partial class Form1 : Form
    {
        private Bitmap image, image2;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = null;
                // image.Dispose();
                image = new Bitmap(dialog.FileName);
                image2 = new Bitmap(image.Width, image.Height);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*) | *.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
            {
                try
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public int clamp(int value, int min, int max) { return value < min ? min : value > max ? max : value; }

        public int[] CalculateHistogram(Bitmap image)
        {
            int[] hist = new int[256];

            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    Color color = image.GetPixel(x, y);
                    hist[color.R]++;
                }
            return hist;
        }

        #region pointbin

        public Bitmap pointbin(Bitmap source)
        {
            int treshold = 150;
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    int average = (int)(color.R + color.B + color.G) / 3;
                    result.SetPixel(i, j, average < treshold ? Color.Black : Color.White);
                }
            }

            return result;
        }

        private void pointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = pointbin(image);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        #endregion

        #region niblack

        int binClamp(int val, int level)
        {
            int resVal = 0;
            int maxVal = 255;
            if (val >= level) return maxVal;
            return resVal;
        }

        public Bitmap ExecuteNiblack(Bitmap source) {
            int m_size = 3;
            int T = 0;
            double k = 0.2;
            double sig = 0;
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    int radX = m_size / 2;
                    int radY = m_size / 2;
                    double new_color = 0;

                    for (int a = -radY; a <= radY; a++)
                        for (int b = -radX; b <= radX; b++)
                        {
                            int idX = clamp(i + b, 0, source.Width - 1);
                            int idY = clamp(j + a, 0, source.Height - 1);
                            Color neibCol = source.GetPixel(idX, idY);
                            new_color += neibCol.G;
                        }

                    new_color = new_color / (m_size * m_size);

                    for (int a = -radY; a <= radY; a++)
                        for (int b = -radX; b <= radX; b++)
                        {
                            int idX = clamp(i + b, 0, source.Width - 1);
                            int idY = clamp(j + a, 0, source.Height - 1);
                            Color neibCol = source.GetPixel(idX, idY);
                            sig += (neibCol.G - new_color) * (neibCol.G - new_color);
                        }
                    sig = Math.Sqrt(sig / (m_size * m_size));
                    T = (int)(new_color + k * sig);
                }

            Bitmap result = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    Color sourceCol2 = source.GetPixel(i, j);
                    Color resultCol = Color.FromArgb((int)(binClamp((int)(0.299 * sourceCol2.R + 0.587 * sourceCol2.G + 0.114 * sourceCol2.B), T)),
                                                     (int)(binClamp((int)(0.299 * sourceCol2.R + 0.587 * sourceCol2.G + 0.114 * sourceCol2.B), T)),
                                                     (int)(binClamp((int)(0.299 * sourceCol2.R + 0.587 * sourceCol2.G + 0.114 * sourceCol2.B), T)));
                    result.SetPixel(i, j, resultCol);
                }
            return result;
        }

        private void niblackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = ExecuteNiblack(image);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        #endregion

        #region globalhist

        public Bitmap GlobalGist(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap resImage = new Bitmap(width, height);

            int[] hist = CalculateHistogram(sourceImage);

            int histSum = hist.Sum();
            int cut = (int)(histSum * 0.05);

            for (int i = 0; i < 255; i++)
            {
                if (hist[i] < cut)
                {
                    cut -= hist[i];
                    hist[i] = 0;
                }

                if (cut <= 0) break;
            }

            cut = (int)(histSum * 0.05);

            for (int i = 255; i < 0; i--)
            {
                if (hist[i] < cut)
                {
                    cut -= hist[i];
                    hist[i] = 0;
                }

                if (cut <= 0) break;
            }

            int t = 0;

            int weight = 0;
            for (int i = 0; i < 255; i++)
            {
                if (hist[i] == 0) continue;
                weight += hist[i] * i;
            }

            t = (int)(weight / hist.Sum());

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color color = sourceImage.GetPixel(x, y);
                    if (color.R >= t) resImage.SetPixel(x, y, Color.White);
                    else resImage.SetPixel(x, y, Color.Black);
                }
            return resImage;
        }

        private void globalhistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = GlobalGist(image);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        #endregion

        #region bilateral
        public Bitmap BilaterialExecute(Bitmap source)
        {
            Bitmap resultimage = new Bitmap(source);
            int radius = 1;
            int sigma = 5;
            int size = 2 * radius + 1;
            float[,] kernel = new float[size, size];
            float norm = 0;
            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i) / 2 * (sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;

            for (int y = 0; y < source.Height; y++)
                for (int x = 0; x < source.Width; x++)
                {
                    Color Color = NewPixelColorBilaterial(source, kernel, x, y);
                    resultimage.SetPixel(x, y, Color);
                }
            return resultimage;
        }
        public Color NewPixelColorBilaterial(Bitmap source, float[,] kernel, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float res = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = clamp(x + k, 0, source.Width - 1);
                    int idY = clamp(y + l, 0, source.Height - 1);
                    Color neighborColor = source.GetPixel(idX, idY);
                    res += neighborColor.R * kernel[k + radiusX, l + radiusY];
                }
            return Color.FromArgb(clamp((int)res, 0, 255),
                                 clamp((int)res, 0, 255),
                                 clamp((int)res, 0, 255));
        }

        private void bilateralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = BilaterialExecute(image);
            image = result;
            pictureBox1.Image = image;
        }

        #endregion

        #region median

        public Bitmap MedianExecute(Bitmap source) {
            Bitmap resultImage = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                    resultImage.SetPixel(i, j, NewPixelColorMedian(source, i, j));
            }

            return resultImage;
        }

        public Color NewPixelColorMedian(Bitmap source, int x, int y)
        {
            Color resultColor = source.GetPixel(x, y);
            int radiusX = 2;
            int radiusY = 2;
            List<int> listR = new List<int>();
            List<int> listG = new List<int>();
            List<int> listB = new List<int>();

            int idx;
            int idy;
            for (int l = -radiusX; l <= radiusX; ++l)
                for (int k = -radiusY; k <= radiusY; ++k)
                {
                    idx = clamp(x + l, 0, source.Width - 1);
                    idy = clamp(y + k, 0, source.Height - 1);
                    listR.Add(source.GetPixel(idx, idy).R);
                    listG.Add(source.GetPixel(idx, idy).G);
                    listB.Add(source.GetPixel(idx, idy).B);
                }
            listR.Sort();
            listG.Sort();
            listB.Sort();

            int d1, d2, d3;
            d1 = clamp((int)listR[listR.Count() / 2], 0, 255);
            d2 = clamp((int)listG[listG.Count() / 2], 0, 255);
            d3 = clamp((int)listB[listB.Count() / 2], 0, 255);
            resultColor = Color.FromArgb(d1, d2, d3);
            return resultColor;
        }

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = MedianExecute(image);
            image = result;
            pictureBox1.Image = image;
        }

        #endregion

        #region gauss

        public Bitmap GaussExecute(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            int size = source.Height * source.Width;
            byte[] noise = new byte[size];
            double[] gaussian = new double[256]; // Гистограмма распределения шумовой составляющей
            int sigma = 50;
            int z = 0;
            Random rnd = new Random();
            double sum = 0;
            for (int i = 0; i < 256; i++)
            {
                gaussian[i] = (double)((1 / (Math.Sqrt(2 * Math.PI) * sigma)) * Math.Exp(z - Math.Pow(i, 2) / (2 * Math.Pow(sigma, 2))));
                sum += gaussian[i];
            }

            for (int i = 0; i < 256; i++)
            {
                gaussian[i] /= sum;
                gaussian[i] *= size;
                gaussian[i] = (int)Math.Floor(gaussian[i]);
            }

            int count = 0;
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < (int)gaussian[i]; j++)
                {
                    noise[j + count] = (byte)i;
                }
                count += (int)gaussian[i];
            }

            for (int i = 0; i < size - count; i++)
            {
                noise[count + i] = 0;
            }

            noise = noise.OrderBy(x => rnd.Next()).ToArray();


            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color color = image.GetPixel(j, i);

                    result.SetPixel(j, i, Color.FromArgb(clamp(color.R + noise[source.Width * i + j], 0, 255),
                        clamp(color.G + noise[source.Width * i + j], 0, 255),
                        clamp(color.B + noise[source.Width * i + j], 0, 255)));

                }
            }
            return result;
        }

        private void gaussToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = GaussExecute(image);
            image2 = image;
            image = result;
            pictureBox1.Image = result;
            pictureBox1.Refresh();
            pictureBox2.Image = image2;
            pictureBox2.Refresh();

        }

        #endregion

        #region uniform

        public float[] Uniform(int size)
        {
            double a = 0;
            double b = 60;

            var uniform = new float[256];
            float sum = 0f;

            for (int i = 0; i < 256; i++)
            {
                float step = i;
                if (step >= a && step <= b)
                    uniform[i] = (1 / (float)(b - a));
                else
                    uniform[i] = 0;

                sum += uniform[i];
            }

            for (int i = 0; i < 256; i++)
            {
                uniform[i] /= sum;
                uniform[i] *= size;
                uniform[i] = (int)Math.Floor(uniform[i]);
            }

            return uniform;
        }
        protected byte[] ComputeNoise(float[] uniform, int size)
        {
            Random random = new Random();
            int count = 0;
            var noise = new byte[size];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < (int)uniform[i]; j++)
                    noise[j + count] = (byte)i;

                count += (int)uniform[i];
            }

            for (int i = 0; i < size - count; i++)
                noise[count + i] = 0;

            noise = noise.OrderBy(x => random.Next()).ToArray();
            return noise;
        }

        public Bitmap CalculateBitmap(Bitmap sourceImage, float[] uniform)
        {
            int size = sourceImage.Width * sourceImage.Height;

            var noise = ComputeNoise(uniform, size);

            var resImage = new Bitmap(sourceImage);

            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color color = sourceImage.GetPixel(x, y);
                    var newValue = clamp(GetBrightness(color) +
                    noise[sourceImage.Width * y + x], 0, 255);

                    resImage.SetPixel(x, y, Color.FromArgb(newValue, newValue, newValue));
                }
            return resImage;
        }
        private static byte GetBrightness(Color color)
        {
            return (byte)(.299 * color.R + .587 * color.G + .114 * color.B);
        }

        private void uniformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = CalculateBitmap(image, Uniform(image.Width * image.Height));
            image2 = image;
            image = result;
            pictureBox1.Image = result;
            pictureBox1.Refresh();
            pictureBox2.Image = image2;
            pictureBox2.Refresh();
        }

        #endregion

        #region PSNR_SSIM

        private bool pictureBoxIsEmpty()
        {
            if (pictureBox1.Image == null || pictureBox2.Image == null) MessageBox.Show("Загрузите оба изображения.", "Ошибка!");
            return (pictureBox1.Image == null || pictureBox2.Image == null);
        }
        private void pSNRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxIsEmpty()) return;
            PSNR filter = new PSNR();
            Cursor.Current = Cursors.WaitCursor;
            MessageBox.Show(PSNR.Execute((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image).ToString());
            Cursor.Current = Cursors.Default;

        }

        private void sSIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxIsEmpty()) return;
            SSIM filter = new SSIM();
            Cursor.Current = Cursors.WaitCursor;
            MessageBox.Show(SSIM.Execute((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image).ToString());
            Cursor.Current = Cursors.Default;
        }

        #endregion

    }
}
