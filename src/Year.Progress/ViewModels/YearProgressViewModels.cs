namespace Year.Progress.ViewModels
{
    using Reactive.Bindings;
    using System;
    using System.Linq;
    using System.Reactive.Linq;

    public class YearProgressViewModels
    {
        public ReactiveProperty<string> Time { get; }

        public ReactiveProperty<double> Progress { get; }

        public YearProgressViewModels()
        {
            Time = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(indexer => DateTime.Now.ToString("hh':'mm':'ss"))
                .ToReactiveProperty();

            Progress = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(indexer =>
                {
                    var now = DateTime.Now;
                    var numerator = now.DayOfYear * 24.0 * 60.0 * 60.0 + now.Hour * 60.0 * 60.0 + now.Minute * 60.0 + now.Second;
                    var denominator = (DateTime.IsLeapYear(now.Year) ? 366 : 365) * 24.0 * 60.0 * 60.0;
                    return Math.Round(100 - numerator / denominator * 100, 1);
                }).ToReactiveProperty();
        }
    }
}
