using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Configuration;
using System.Collections;
using System.ComponentModel.Design;
using System.Runtime.InteropServices.ComTypes;

namespace Trainings
{
    public class TimetableDatabase: IDatabase
    {
        DataContext database = new DataContext(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Training.mdf;Integrated Security=True;Connect Timeout=30");

        public List<Training> Trainings
        {
            get
            {
                List<Training> trainings = new List<Training>();
                Table<Training> trainingTable = database.GetTable<Training>();

                foreach (Training training in trainingTable)
                    trainings.Add(training);
                trainings.Sort();
                return trainings;
            }
        }

        public List<string> Clients
        {
            get
            {
                HashSet<string> clients = new HashSet<string>();
                foreach (Training training in Trainings)
                    clients.Add(training.ClientName);
                return clients.ToList();    
            }
        }

        public int this[string clientName]
        {
            get
            {
                int cost = 0;
                bool isClientExist = false;
                foreach (Training training in Trainings)
                    if (training.ClientName == clientName)
                    {
                        cost += training.Price;
                        isClientExist = true;
                    }
                return isClientExist ? cost : -1;
            }
        }

        public Training getTraining(int id)
        {
            List<Training> trainings = new List<Training>();
            Table<Training> trainingTable = database.GetTable<Training>();

            foreach (Training training in trainingTable)
                if (training.ID == id)
                    return training;
            return new Training();
        }

        public void addTraining(Training training)
        {
            Table<Training> trainigs = database.GetTable<Training>();
            trainigs.InsertOnSubmit(training);
            database.SubmitChanges();
        }

        public void deleteTraining(int id)
        {
            Table<Training> trainingTable = database.GetTable<Training>();
            Training deletingTraining = null;
            foreach (Training t in trainingTable)
                if (t.ID == id)
                    deletingTraining = t;
            if (deletingTraining != null)
            {
                trainingTable.DeleteOnSubmit(deletingTraining);
                database.SubmitChanges();
            }
        }

        public void editTraining(Training training)
        {
            /*deleteTraining(training.ID);
            database = new DataContext(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Training.mdf;Integrated Security=True;Connect Timeout=30");
            addTraining(training); */
            Table<Training> trainingTable = database.GetTable<Training>();
            Training trainingToEdit = (from t in trainingTable
                                       where t.ID == training.ID
                                       select t).First();

            trainingToEdit.ClientName = training.ClientName;
            trainingToEdit.TimeFrom = training.TimeFrom;
            trainingToEdit.TimeTo = training.TimeTo;
            trainingToEdit.Price = training.Price;
            trainingToEdit.PayMethod = training.PayMethod;
            database.SubmitChanges();
               
        }

    }
}
