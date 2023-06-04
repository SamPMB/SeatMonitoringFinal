namespace SeatMonitoringLibrary
{
    public class StudentModel
    {
        int studentId;
        string user_id;
        int seatState;
        int seatId;
        int year;
        long awayTime;
        string firstName = "";
        string lastName = "";

        public string User_id { get { return user_id; } set { user_id = value; } }
        public string First_Name { get { return firstName; } set { firstName = value; } }
        public string Last_Name { get { return lastName; } set { lastName = value; } }
        public int SeatId { get { return seatId; } set { seatId = value; } }
        public long AwayTime { get { return awayTime; } set { awayTime = value; } }
        public int Year { get { return year; } set { year = value; } }
        public int StudentId { get { return studentId; } set { studentId = value; } }
        public int SeatState { get { return seatState; } set { seatState = value; } }

    }
}
