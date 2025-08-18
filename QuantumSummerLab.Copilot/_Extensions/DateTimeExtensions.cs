﻿namespace QuantumSummerLab.Copilot.Extensions;

public static class DateTimeExtensions
{
    // From: https://rmauro.dev/calculate-time-ago-with-csharp/
    public static string AsTimeAgo(this DateTime dateTime)
    {
        TimeSpan timeSpan = DateTime.UtcNow.Subtract(dateTime);

        return timeSpan.TotalSeconds switch
        {
            <= 1 => "just now",
            <= 60 => $"{timeSpan.Seconds} seconds ago",

            _ => timeSpan.TotalMinutes switch
            {
                <= 1 => "about a minute ago",
                < 60 => $"about {timeSpan.Minutes} minutes ago",
                _ => timeSpan.TotalHours switch
                {
                    <= 1 => "about an hour ago",
                    < 24 => $"about {timeSpan.Hours} hours ago",
                    _ => timeSpan.TotalDays switch
                    {
                        <= 1 => "yesterday",
                        <= 30 => $"about {timeSpan.Days} days ago",

                        <= 60 => "about a month ago",
                        < 365 => $"about {timeSpan.Days / 30} months ago",

                        <= 365 * 2 => "about a year ago",
                        _ => $"about {timeSpan.Days / 365} years ago"
                    }
                }
            }
        };
    }

    public static string AsDuration(this int duration)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(duration / 1000);

        return timeSpan.TotalSeconds switch
        {
            <= 1 => "less than one second",
            < 60 => $"about {timeSpan.Seconds} seconds",

            _ => timeSpan.TotalMinutes switch
            {
                <= 1 => "about a minute",
                < 60 => $"about {timeSpan.Minutes} minutes",
                _ => timeSpan.TotalHours switch
                {
                    <= 1 => "about an hour",
                    < 24 => $"about {timeSpan.Hours} hours",
                    _ => timeSpan.TotalDays switch
                    {
                        <= 1 => "about a day",
                        <= 30 => $"about {timeSpan.Days} days",

                        <= 60 => "about a month",
                        < 365 => $"about {timeSpan.Days / 30} months",

                        <= 365 * 2 => "about a year",
                        _ => $"about {timeSpan.Days / 365} years"
                    }
                }
            }
        };
    }
}