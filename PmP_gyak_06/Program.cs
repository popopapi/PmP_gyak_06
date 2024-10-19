using System.Globalization;

namespace PmP_gyak_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1.
            Book b = new Book("The Hobbit - or There and Back Again", "J.R.R. Tolkien", 1937, 312);
            Console.WriteLine(b.AllData());

            #endregion 1.

            #region 2.
            Teglalap t = new Teglalap(30, 3, "Red");
            Console.WriteLine(t.IsValid());
            t.Draw(10, 10);
            Teglalap t2 = new Teglalap(0, 3, "Green");
            Console.WriteLine(t2.IsValid());
            t2.Draw(10, 15);
            #endregion 2.

            #region 3.
            Runner runner1 = new Runner("Alice", 0, 5);
            Runner runner2 = new Runner("Bob", 1, 3);

            int targetDistance = 4;

            while (runner1.GetDistance() < targetDistance && runner2.GetDistance() < targetDistance)
            {
                runner1.RefreshDistance(1);
                runner2.RefreshDistance(1);

                Console.Clear();
                runner1.Show();
                runner2.Show();

                Thread.Sleep(1000); 
            }
            #endregion 3.

            #region 4.
            CaesarRejtJel cipher = new(3);
            string encodedMessage = cipher.Encode("Hello, World!");
            Console.WriteLine("Titkosított üzenet: " + encodedMessage);

            string decodedMessage = cipher.Decode(encodedMessage);
            Console.WriteLine("Visszafejtett üzenet: " + decodedMessage);

            #endregion 4.

            #region 5.
            string filePath = "NHANES_1999-2018.csv";

            List<Person> persons = new List<Person>();

            var lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++) 
            {
                var values = lines[i].Split(',');
                int seqn = int.Parse(values[0], CultureInfo.InvariantCulture);
                string survey = values[1];
                int gender = (int)double.Parse(values[2], CultureInfo.InvariantCulture);
                int age = (int)double.Parse(values[3], CultureInfo.InvariantCulture);
                double bmi = double.Parse(values[4], CultureInfo.InvariantCulture);
                double glucose = double.Parse(values[5], CultureInfo.InvariantCulture);

                persons.Add(new Person(seqn, survey, gender, age, bmi, glucose));
            }
            Console.WriteLine("Milyen időszakot szeretne vizsgálni? (pl. 1999-2000)");
            string targetSurvey = Console.ReadLine();
            List<Person> targetSurveyPersons = new List<Person>();
            foreach (var person in persons)
            {
                if (person.Survey == targetSurvey)
                {
                    targetSurveyPersons.Add(person);
                }
            }

            List<double> maleBmi = new List<double>();
            List<double> femaleBmi = new List<double>();
            foreach (var person in targetSurveyPersons)
            {
                if (person.Gender == 1)
                {
                    maleBmi.Add(person.Bmi);
                }
                else if (person.Gender == 2)
                {
                    femaleBmi.Add(person.Bmi);
                }
            }

            double maleBmiAverage = maleBmi.Count > 0 ? maleBmi.Average() : 0;
            double femaleBmiAverage = femaleBmi.Count > 0 ? femaleBmi.Average() : 0;

            Console.WriteLine($"1. A(z) {targetSurvey} felmérésben a férfiak átlagos BMI-je: {maleBmiAverage:F2}");
            Console.WriteLine($"1. A(z) {targetSurvey} felmérésben a nők átlagos BMI-je: {femaleBmiAverage:F2}");

            // 2. Egy adott felmérésben az alanyok hány százalékának volt 5.6-nál magasabb a vércukorszintje?
            int highGlucoseCount = 0;
            foreach (var person in targetSurveyPersons)
            {
                if (person.Glucose > 5.6)
                {
                    highGlucoseCount++;
                }
            }
            double highGlucosePercentage = (double)highGlucoseCount / targetSurveyPersons.Count * 100;

            Console.WriteLine($"2. A(z) {targetSurvey} felmérésben az alanyok {highGlucosePercentage:F2}%-ának volt 5.6-nál magasabb a vércukorszintje.");

            // 3. Egy maximális BMI-vel rendelkező alanynak mennyi a vércukorszintje?
            double maxBmi = double.MinValue;
            Person maxBmiPerson = null;
            foreach (var person in persons)
            {
                if (person.Bmi > maxBmi)
                {
                    maxBmi = person.Bmi;
                    maxBmiPerson = person;
                }
            }
            double glucoseForMaxBmi = maxBmiPerson != null ? maxBmiPerson.Glucose : 0;

            Console.WriteLine($"3. A maximális BMI-vel rendelkező alany vércukorszintje: {glucoseForMaxBmi:F2}");

            // 4. A teljes adathalmazban mi a túlsúlyos (legalább 30.0-as BMI) személyek átlagos életkora?
            List<int> overweightAges = new List<int>();
            foreach (var person in persons)
            {
                if (person.Bmi >= 30.0)
                {
                    overweightAges.Add(person.Age);
                }
            }
            double averageAgeOverweight = overweightAges.Count > 0 ? overweightAges.Average() : 0;

            Console.WriteLine($"4. A túlzsúlyos személyek átlagos életkora: {averageAgeOverweight:F2}");
            #endregion 5.
        }
    }
    


 }

 