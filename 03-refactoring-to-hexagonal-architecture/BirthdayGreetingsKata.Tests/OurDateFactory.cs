using System;

namespace BirthdayGreetingsKata.Tests;

public static class OurDateFactory {
    public static OurDate CreateOurDate(string date) {
        return new OurDate(DateTime.ParseExact(date, "yyyy/MM/dd", null));
    }
}