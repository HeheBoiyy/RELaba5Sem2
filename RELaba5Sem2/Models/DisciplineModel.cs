using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELaba5Sem2.Models
{
    public class Discipline : INotifyPropertyChanged
    {
        private string _name;
        private string _teacherName;
        private DateTime _examDate;
        private string _difficulty;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string TeacherName
        {
            get { return _teacherName; }
            set
            {
                _teacherName = value;
                OnPropertyChanged("TeacherName");
            }
        }

        public DateTime ExamDate
        {
            get { return _examDate; }
            set
            {
                _examDate = value;
                OnPropertyChanged("ExamDate");
            }
        }

        public string Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                OnPropertyChanged("Difficulty");
            }
        }

        public DateTime PrepStartDate
        {
            get
            {
                switch (_difficulty)
                {
                    case "Лёгкий":
                        return _examDate;
                    case "Средний":
                        return _examDate.AddDays(-14);
                    case "Сложный":
                        return _examDate.AddMonths(-1);
                    default:
                        return _examDate;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
