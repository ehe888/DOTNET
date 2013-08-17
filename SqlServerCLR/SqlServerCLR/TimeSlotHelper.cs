using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Server;

namespace SqlServerCLR
{
    public class TimeSlotHelper
    {

        [SqlFunction()]
        public static long ToBitMap(DateTimeOffset startTime, DateTimeOffset endTime, long slotIndex) {
            if (startTime == null || endTime == null || startTime >= endTime || !(startTime.Year == endTime.Year
                && startTime.Month == endTime.Month && startTime.Day == endTime.Day && startTime.Offset == endTime.Offset)) {
                    return 0;
            }

            int startHour = startTime.Hour; //from 0 to 23
            int endHour = endTime.Hour;

            int slotStartHour = (int)slotIndex * 4;
            int slotEndHour = slotStartHour + 3;

            if (startHour > slotEndHour || endHour < slotStartHour) { //No overlap
                return 0;
            }

            
            if (startHour < slotStartHour) {//e.g 4:00 - 8:00, startTime is 3:45,then the recal starttime is 04:00:00
                startTime = new DateTimeOffset(startTime.Year,
                            startTime.Month, startTime.Day, slotStartHour, 0, 0, startTime.Offset);    
            }
            if (endHour > slotEndHour) {// e.g. 4:00 - 8:00 endTime is 9:50, then the recal endtime is 09:00:00
                endTime = new DateTimeOffset(startTime.Year,
                            startTime.Month, startTime.Day, slotEndHour + 1, 0, 0, startTime.Offset);  
            }

            DateTimeOffset cursor = startTime;
            UInt64 result = 0 | (UInt64)slotIndex << 48;

            while (cursor < endTime) {
                int hourShift = (3 - cursor.Hour % 4) * 12;
                int minuteShift = 11 - cursor.Minute / 5;

                result |= ((UInt64)1 << (minuteShift + hourShift));
                
                cursor = cursor.AddMinutes(5);
            }
            return (long)result;
        }

        [SqlFunction()]
        public static Boolean IsOverTime(DateTimeOffset createTime, int limit)
        {
            if (createTime == null) {
                return true;
            }

            return DateTimeOffset.UtcNow.Subtract(createTime).TotalMinutes > limit;
        }
    }
}
