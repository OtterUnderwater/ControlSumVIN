using LibraryDLL;
using System;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace LibraryUnitTests
{
    [TestClass]
    public class UnitTests
    {
        // Правило наименование: ТестирующийсяМетод_Сценарий_ОжидаемоеПоведение
        // Или ТестирующийсяКласс_ТестирующийсяМетод_СостояниеИОжидаемыйРезультат

        /// <summary>
        /// Проверка, что GetNum правильно заменяет корректные буквы на цифры
        /// </summary>  
        [TestMethod]
        public void GetNum_CorrectLetterA_1returned()
        {
            //Используем модель тестов Arrange - Act - Assert
            //Arrange (устанавливать): устанавливает начальные условия
            char letter = 'A';
            int expected = 1;
            // Act (действие): выполняет тест (вызов функции)
            СheckSumDLL obj = new СheckSumDLL(null);
            int result = obj.GetNum(letter);
            //Assert (утверждение): верифицирует результат теста
            Assert.AreEqual(expected, result);
            //метод Equals() сравнивает ссылки, AreEqual() значения
        }

        /// <summary>
        /// Проверка, что GetNum правильно заменяет некорректные буквы на цифры
        /// </summary> 
        [TestMethod]
        public void GetNum_IncorrectLetterI_0returned()
        { 
            //Arrange
            char letter = 'I';
            int expected = 0;
            // Act
            СheckSumDLL obj = new СheckSumDLL(null);
            int result = obj.GetNum(letter);
            //Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Проверка, что СonverterNum возвращает не null
        /// </summary> 
        [TestMethod]
        public void СonverterNum_СonverterNumObj_NotNullReturned()
        {
            СheckSumDLL obj = new СheckSumDLL("JHMCM56557C404453");
            int[] result = obj.СonverterNum();
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Проверка, что СonverterNum возвращает правильный массив цифр
        /// </summary> 
        [TestMethod]
        public void СonverterNum_СheckObj123DEFGH_12345678Returned()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };
            СheckSumDLL obj = new СheckSumDLL("123DEFGH");
            int[] result = obj.СonverterNum();
            CollectionAssert.AreEqual(expected, result);
        }

        /// <summary>
        /// Проверка, что СalculatingСheckSum возвращает правильное контрольное число
        /// </summary> 
        [TestMethod]
        public void СalculatingСheckSum_СheckCHK_5Returned()
        {
            char expected = '5';
            СheckSumDLL obj = new СheckSumDLL("JHMCM56557C404453");
            char result = obj.СalculatingСheckSum();
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Проверка, что СheckingCHKAndСheckSum возвращает true
        /// </summary> 
        [TestMethod]
        public void СheckingCHKAndСheckSum_СheckCHK_TrueReturned()
        {
            СheckSumDLL obj = new СheckSumDLL("JHMCM56557C404453");
            bool result = obj.СheckingCHKAndСheckSum();
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проверка, что СheckingCHK возвращает true
        /// </summary> 
        [TestMethod]
        public void СheckingCHK_СheckCHK_TrueReturned()
        {
            СheckSumDLL obj = new СheckSumDLL("JHMCM56557C404453");
            bool result = obj.СheckingCHK();
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проверка, что СheckingCorrectness возвращает true (введенные данные корректны)
        /// </summary> 
        [TestMethod]
        public void СheckingCorrectness_СheckCHK_TrueReturned()
        {
            СheckSumDLL obj = new СheckSumDLL("JHMCM56557C404453");
            bool result = obj.СheckingCorrectness();
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проверка, что контрольная сумма совпадает (JHMCM56557C404453)
        /// </summary> 
        [TestMethod]
        public void ExaminationСheckSum_СheckObjJHMCM56557C404453_CHKMatchesReturned()
        {
            string expected = "Контрольная сумма совпадает";
            СheckSumDLL obj = new СheckSumDLL("JHMCM56557C404453");
            string result = obj.ExaminationСheckSum();
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Проверка, что контрольная сумма не совпадает (JHMCM56577C404453)
        /// </summary> 
        [TestMethod]
        public void ExaminationСheckSum_СheckObjJHMCM56577C404453_CHKNotMatchesReturned()
        {
            string expected = "Контрольная сумма не совпадает";
            СheckSumDLL obj = new СheckSumDLL("JHMCM56577C404453");
            string result = obj.ExaminationСheckSum();
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Проверка, что контрольная сумма неправильная (JHMCM565M7C404453)
        /// </summary> 
        [TestMethod]
        public void ExaminationСheckSum_СheckObjJHMCM565M7C404453_CHKNotMatchesReturned()
        {
            string expected = "Число контрольной суммы в позиции 9 введено некорректно!";
            СheckSumDLL obj = new СheckSumDLL("JHMCM565M7C404453");
            string result = obj.ExaminationСheckSum();
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Проверка, что строка введена неккоректно (JHMCMI55Q7C404453)
        /// </summary> 
        [TestMethod]
        public void ExaminationСheckSum_СheckObjJHMCMI55Q7C404453_IncorrectlyReturned()
        {
            string expected = "Строка введена некорректно!";
            СheckSumDLL obj = new СheckSumDLL("JHMCMI55Q7C404453");
            string result = obj.ExaminationСheckSum();
            Assert.AreEqual(expected, result);
        }
    }
}