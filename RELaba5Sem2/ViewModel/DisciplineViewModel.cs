using RELaba5Sem2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RELaba5Sem2.src;
using System.Windows;
namespace RELaba5Sem2.ViewModel
{
    public class DisciplineViewModel
    {
        MainWindow mv = (MainWindow)Application.Current.MainWindow;
        public ObservableCollection<Discipline> Disciplines { get; set; }

        public Discipline SelectedItem { get; set; }

        public DisciplineViewModel()
        {
            Disciplines = new ObservableCollection<Discipline>();
            mv.Difficulty.Items.Add("Лёгкий");
            mv.Difficulty.Items.Add("Средний");
            mv.Difficulty.Items.Add("Сложный");
        }
        public RelayCommand AddDiscipline => new RelayCommand(execute => _AddDiscipline(mv.NameBut.Text, mv.FIOBut.Text, mv.Difficulty.SelectedItem.ToString(), mv.TimeEx.SelectedDate.GetValueOrDefault()));
        public RelayCommand RemoveDiscipline => new RelayCommand(execute => _RemoveDiscipline(SelectedItem));
        public void _AddDiscipline(string name, string tname, string diff, DateTime Date)
        {
            if (name == "" || tname =="" || diff ==null || Date == DateTime.MinValue)
            {
                MessageBox.Show("Какое то из полей не заполнено");
            }
            else
            {
                Discipline temp = new Discipline()
                {
                    Name = name,
                    TeacherName = tname,
                    Difficulty = diff,
                    ExamDate = Date
                };
                Disciplines.Add(temp);
            }
        }

        public void _RemoveDiscipline(Discipline discipline)
        {
            Disciplines.Remove(discipline);
        }
    }
}
