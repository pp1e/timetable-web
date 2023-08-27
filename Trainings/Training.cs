using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Trainings
{
    [Table(Name = "TRAINING")]
    public class Training : IEquatable<Training>, IComparable<Training>
    {
        private int id;
        private string clientName;
        private PayMethod payMethod;
        private DateTime timeFrom, timeTo;
        private int price;

        public Training(int id, string clientName, PayMethod payMethod, DateTime timeFrom, DateTime timeTo, int price)
        {
            id = 1;
            ClientName = clientName;
            PayMethod = payMethod;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            Price = price;
        }

        public Training()
        {
            id = -1;
            ClientName = "";
            PayMethod = PayMethod.Cash;
            TimeFrom = DateTime.Now;
            TimeTo = DateTime.Now.AddHours(1);
            Price = 1000;
        }

        [Column(Name = "ID", IsPrimaryKey = true, IsDbGenerated = true)] public int ID {
            get
            {
                return id;
            } 
            set
            {
                id = value;
            }
        }

        [Column(Name = "CLIENT_NAME")]
        public string ClientName
        {
            get
            {
                return clientName;
            }
            set
            {
                Regex regex = new Regex("^\\D+$");
                if (value != "")
                    if (char.IsLower(value[0]) | !regex.IsMatch(value))
                        throw new FormatException("Имя клиента должно начинаться с заглавной буквы и не содержать цифр!");
                clientName = value;
            }
        }

        public PayMethod PayMethod
        {
            get
            {
                return payMethod;
            }
            set
            {
                payMethod = value;
            }
        }

        [Column(Name = "PAY_METHOD")]
        private int PayMethodFromInt
        {
            set
            {
                if (value == 1)
                    payMethod = PayMethod.Card;
                else
                    payMethod = PayMethod.Cash;
            }
            get
            {
                return (int)payMethod;
            }
        }

        [Column(Name = "TIME_FROM")]
        public DateTime TimeFrom
        {
            get
            {
                return timeFrom;
            }
            set
            {
               /* if ((TimeTo != DateTime.MinValue) && (value >= TimeTo) )
                    throw new FormatException("Время начала должно стоять перед временем конца!");*/
                timeFrom = value;
            }
        }

        [Column(Name = "TIME_TO")]
        public DateTime TimeTo
        {
            get
            {
                return timeTo;
            }
            set
            {
                if ( (TimeFrom != DateTime.MinValue) && (value <= TimeFrom) )
                        throw new FormatException("Окончание тренировки не может быть раньше начала!");
                timeTo = value;
            }
        }

        public String TableTime
        {
            get
            {
                return TimeFrom.ToString("d") + ", " + TimeFrom.ToString("t") + "-" + TimeTo.ToString("t");
            }
        }

        public String TablePayMethod
        {
            get
            {
                switch (payMethod)
                {
                    case PayMethod.Card:
                        return "Карта";
                    case PayMethod.Cash:
                        return "Наличные";
                    default:
                        return "-";
                }
            }
        }

        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public String TableDayOfWeek
        {
            get
            {
                switch (timeFrom.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        return "Понедельник";
                    case DayOfWeek.Tuesday:
                        return "Вторник";
                    case DayOfWeek.Wednesday:
                        return "Среда";
                    case DayOfWeek.Thursday:
                        return "Четверг";
                    case DayOfWeek.Friday:
                        return "Пятница";
                    case DayOfWeek.Saturday:
                        return "Суббота";
                    case DayOfWeek.Sunday:
                        return "Воскресенье";
                    default:
                        return "-";

                }
            }
        }

        public int CompareTo(Training other)
        {
            return TimeFrom.CompareTo(other.TimeFrom);
        }

        public bool Equals(Training other)
        {
            if (other == null)
                return false;
            else
                return ( (this.TimeFrom >= other.TimeFrom) && (this.TimeFrom < other.TimeTo) ) || ( (this.TimeTo > other.TimeFrom) && (this.TimeTo <= other.TimeTo) );
        }

        public override string ToString()
        {
            return clientName + "\n" + payMethod + "\n" + timeFrom + "\n" + timeTo + "\n" + price + "\n";
        }
    }
}
