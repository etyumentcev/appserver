namespace SpaceBattle.Tests.StepDefinitions
{
    [Binding]
    public class ВекторN_МерногоВеторногоПространстваStepDefinitions
    {
        Vector a;
        Vector b;
        Vector result;
        Exception _ex;


        [Given(@"двухмерный вектор a с координатами \((.*), (.*)\)")]
        public void GivenВекторAСКоординатами(int x, int y)
        {
            a = new Vector(x, y);
        }

        [Given(@"двухмерный вектор b с координатами \((.*), (.*)\)")]
        public void GivenВекторBСКоординатами(int x, int y)
        {
            b = new Vector(x, y);
        }

        [Given(@"трехмерный вектор b с координатами \((.*), (.*), (.*)\)")]
        public void GivenВекторBСКоординатами(int x, int y, int z)
        {
            b = new Vector(x, y, z);
        }

        [When(@"складываем веторы a и b")]
        public void WhenСкладываемВеторыAИB()
        {
            try
            {
                result = a + b;
            }
            catch(Exception ex)
            {
                _ex = ex;
            }
        }

        [Then(@"получаем вектор с координатами \((.*), (.*)\)\.")]
        public void ThenПолучаемВекторСКоординатами_(int x, int y)
        {
            Assert.Equal(new Vector(x, y), result);
        }

        [Then(@"выбрасывается исключение")]
        public void ThenВыбрасываетсяИсключение()
        {
            Assert.ThrowsAny<Exception>(() => throw _ex);
        }

    }
}
