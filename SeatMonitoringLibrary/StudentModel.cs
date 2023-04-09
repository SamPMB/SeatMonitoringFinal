﻿namespace SeatMonitoringLibrary
{
    public class StudentModel
    {
        int studentId;
        string cardId = "";
        int seatId;
        int year;
        long awayTime;
        string firstName = "";

        public string Id { get { return cardId; } set { cardId = value; } }
        public string First_Name { get { return firstName; } set { firstName = value; } }
        public int Seat { get { return seatId; } set { seatId = value; } }
        public long AwayTime { get { return awayTime; } set { awayTime = value; } }
        public int Year { get { return year; } set { year = value; } }
        public int StudentId { get { return studentId; } set { studentId = value; } }

    }
}
