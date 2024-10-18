using System;
using TechTalk.SpecFlow;

using Game;

namespace Game.Tests.StepDefinitions
{
    [Binding]
    public class УголНаПлоскостиStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        Angle? a;
        Angle? b;
        Angle? result;
        bool? equalityResult;
        string? stringResult;
        Exception? ex;

        public УголНаПлоскостиStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"угол a \((.*), (.*)\)")]
        public void ДопустимУголA(sbyte p0, sbyte p1)
        {   
            a = new Angle(p0, p1);
        }
        
        [Given(@"угол b \((.*), (.*)\)")]
        public void ДопустимУголB(sbyte p0, sbyte p1)
        {
            b = new Angle(p0, p1);
        }
        
        [When(@"складываем углы a и b")]
        public void КогдаСкладываемУглыAИB()
        {
            try
            {
                result = a! + b!;
            }
            catch(Exception exception)
            {
                ex = exception;
            }
        }

        [When(@"сравниваем углы a и b на равенство")]
        public void КогдаСравниваемУглыAИBНаРавенство()
        {
            try
            {
                equalityResult = (a! == b!);
            }
            catch(Exception exception)
            {
                ex = exception;
            }
        }


        [When(@"сравниваем углы a и b на неравенство")]
        public void КогдаСравниваемУглыAИBНаНеравенство()
        {
            try
            {
                equalityResult = (a! != b!);
            }
            catch(Exception exception)
            {
                ex = exception;
            }
        }

        [When(@"конвертирем в строку")]
        public void КогдаКонвертиремВСтроку()
        {
            try
            {
                stringResult = a!.ToString();
            }
            catch(Exception exception)
            {
                ex = exception;
            }
        }
        
        [Then(@"получаем угол \((.*), (.*)\)\.")]
        public void ТоПолучаемУгол_(sbyte p0, sbyte p1)
        {
            Assert.Equal(new Angle(p0, p1), result!);
            Assert.Null(ex);
        }

        [Then(@"получаем истину\.")]
        public void ТоПолучаемИстину()
        {
            Assert.True(equalityResult!);
            Assert.Null(ex);
        }

        [Then(@"получаем ложь\.")]
        public void ТоПолучаемЛожь()
        {
            Assert.False(equalityResult!);
            Assert.Null(ex);
        }

        [Then(@"выбрасывается исключение\.")]
        public void ТоВыбрасываетсяИсключение()
        {
            Assert.NotNull(ex);
        }


        [Then(@"получаем строку ""(.*)""")]
        public void ТоПолучаемСтроку(string p0)
        {
            Assert.Equal(p0, stringResult!);
            Assert.Null(ex);
        }
    }
}
