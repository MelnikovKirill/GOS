using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<Film> films = new List<Film>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            films.Clear();

            films.Add(new Film() { Id = 1, Name = "Звонок", Rejisser = "Мельников", Year = 2008 });
            films.Add(new Film() { Id = 2, Name = "Оно", Rejisser = "Дунаев", Year = 2018 });
            films.Add(new Film() { Id = 3, Name = "1+1", Rejisser = "Лямзина", Year = 2015 });


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = films;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            films.Clear();
        }

        private void saveToFile(string path)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Film>));
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, films);
            }
        }

        private void loadFromFile(string path)
        {
            dataGridView1.Columns.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Film>));
            using (Stream fStream = new FileStream(path, FileMode.Open))
            {
                using (XmlReader reader = XmlReader.Create(fStream))
                {
                    var buffFilms = (List<Film>)serializer.Deserialize(reader);
                    if (buffFilms != null)
                    {
                        films = buffFilms;
                        dataGridView1.DataSource = films;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при загрузке");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveToFile("C:\\Users\\Kiril\\source\\repos\\WinFormsApp1\\WinFormsApp1\\test.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadFromFile("C:\\Users\\Kiril\\source\\repos\\WinFormsApp1\\WinFormsApp1\\test.txt");
        }
     
       private void button5_Click(object sender, EventArgs e)
        {
            getFilmByDirector(textBox1.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            getFilmWithLongTime(Convert.ToInt32(textBox2.Text));
        }

        public void getFilmByDirector(string Rejisser)
        {
            List<Film> res = (from f in films where f.Rejisser == Rejisser select f).ToList();
            dataGridView1.DataSource = res;
        }

        public void getFilmWithLongTime(int Year)
        {
            //List<Film> res = films.Where(p => p.Year == Year).OrderByDescending(p => p.Time).ToList();
            Film res = films.OrderByDescending(p => p.Year).FirstOrDefault(p => p.Year == Year);
            List<Film> f = new List<Film>();
            f.Add(res);
            dataGridView1.DataSource = f;
           
        }

    }
}
