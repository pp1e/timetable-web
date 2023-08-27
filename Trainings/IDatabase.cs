using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainings
{
    public interface IDatabase
    {
        List<Training> Trainings { get; }

        List<string> Clients { get; }

        int this[string clientName] { get; }

        void addTraining(Training training);

        Training getTraining(int id);

        void editTraining(Training training);
    }
}
