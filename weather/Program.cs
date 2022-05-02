using System;
using System.IO;
using System.Collections.Generic;

namespace weather
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"weather.txt";
            string[] lines = File.ReadAllLines(filePath);
            // string myString = "";
            List<double> minT = new List<double>();
            List<int> date = new List<int>();
            List<string> day_of_week = new List<string>(){"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}; 
            foreach (var line in lines[8..39])
                {
                    string[] eachLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if(eachLine.Length!=0){
                        double numericValue;
                        bool isNumber = double.TryParse(eachLine[2], out numericValue);
                        bool isNumber_day = double.TryParse(eachLine[0], out numericValue);
                        if(isNumber_day){
                            date.Add(Convert.ToInt32(eachLine[0]));
                        }else{
                            date.Add(1);
                        }
                        if(isNumber){
                            minT.Add(Convert.ToDouble(eachLine[2]));
                        }else{
                            minT.Add(Convert.ToDouble(eachLine[2].Substring(0,2)));
                        }
                    }
                }  
            double minimumTnumber = minT[0];
            int date_minT = date[0];
            for(int i = 0; i < minT.Count; i++){
                if(minT[i]<minimumTnumber){
                    minimumTnumber = minT[i];
                    date_minT = date[i];
                }
            }
            DateTime dateValue = new DateTime(2002, 6, date_minT);
            string day_minT = day_of_week[(int) dateValue.DayOfWeek];
            if(date_minT==1){
                Console.WriteLine($"The day that have the minimum temperature is on {day_minT} and the date is {date_minT}st June.");
            }else if(date_minT==2){
                Console.WriteLine($"The day that have the minimum temperature is on {day_minT} and the date is {date_minT}nd June.");
            }else if(date_minT==3){
                Console.WriteLine($"The day that have the minimum temperature is on {day_minT} and the date is {date_minT}rd June.");
            }else{
                Console.WriteLine($"The day that have the minimum temperature is on {day_minT} and the date is {date_minT}th June.");
            }
        }
    }
}
