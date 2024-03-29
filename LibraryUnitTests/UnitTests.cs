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
        // ������� ������������: ������������������_��������_������������������
        // ��� ������������������_������������������_����������������������������

        /// <summary>
        /// ��������, ��� GetNum ��������� �������� ���������� ����� �� �����
        /// </summary>  
        [TestMethod]
        public void GetNum_CorrectLetterA_1returned()
        {
            //���������� ������ ������ Arrange - Act - Assert
            //Arrange (�������������): ������������� ��������� �������
            char letter = 'A';
            int expected = 1;
            // Act (��������): ��������� ���� (����� �������)
            �heckSumDLL obj = new �heckSumDLL(null);
            int result = obj.GetNum(letter);
            //Assert (�����������): ������������ ��������� �����
            Assert.AreEqual(expected, result);
            //����� Equals() ���������� ������, AreEqual() ��������
        }

        /// <summary>
        /// ��������, ��� GetNum ��������� �������� ������������ ����� �� �����
        /// </summary> 
        [TestMethod]
        public void GetNum_IncorrectLetterI_0returned()
        { 
            //Arrange
            char letter = 'I';
            int expected = 0;
            // Act
            �heckSumDLL obj = new �heckSumDLL(null);
            int result = obj.GetNum(letter);
            //Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// ��������, ��� �onverterNum ���������� �� null
        /// </summary> 
        [TestMethod]
        public void �onverterNum_�onverterNumObj_NotNullReturned()
        {
            �heckSumDLL obj = new �heckSumDLL("JHMCM56557C404453");
            int[] result = obj.�onverterNum();
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// ��������, ��� �onverterNum ���������� ���������� ������ ����
        /// </summary> 
        [TestMethod]
        public void �onverterNum_�heckObj123DEFGH_12345678Returned()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };
            �heckSumDLL obj = new �heckSumDLL("123DEFGH");
            int[] result = obj.�onverterNum();
            CollectionAssert.AreEqual(expected, result);
        }

        /// <summary>
        /// ��������, ��� �alculating�heckSum ���������� ���������� ����������� �����
        /// </summary> 
        [TestMethod]
        public void �alculating�heckSum_�heckCHK_5Returned()
        {
            char expected = '5';
            �heckSumDLL obj = new �heckSumDLL("JHMCM56557C404453");
            char result = obj.�alculating�heckSum();
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// ��������, ��� �heckingCHKAnd�heckSum ���������� true
        /// </summary> 
        [TestMethod]
        public void �heckingCHKAnd�heckSum_�heckCHK_TrueReturned()
        {
            �heckSumDLL obj = new �heckSumDLL("JHMCM56557C404453");
            bool result = obj.�heckingCHKAnd�heckSum();
            Assert.IsTrue(result);
        }

        /// <summary>
        /// ��������, ��� �heckingCHK ���������� true
        /// </summary> 
        [TestMethod]
        public void �heckingCHK_�heckCHK_TrueReturned()
        {
            �heckSumDLL obj = new �heckSumDLL("JHMCM56557C404453");
            bool result = obj.�heckingCHK();
            Assert.IsTrue(result);
        }

        /// <summary>
        /// ��������, ��� �heckingCorrectness ���������� true (��������� ������ ���������)
        /// </summary> 
        [TestMethod]
        public void �heckingCorrectness_�heckCHK_TrueReturned()
        {
            �heckSumDLL obj = new �heckSumDLL("JHMCM56557C404453");
            bool result = obj.�heckingCorrectness();
            Assert.IsTrue(result);
        }

        /// <summary>
        /// ��������, ��� ����������� ����� ��������� (JHMCM56557C404453)
        /// </summary> 
        [TestMethod]
        public void Examination�heckSum_�heckObjJHMCM56557C404453_CHKMatchesReturned()
        {
            string expected = "����������� ����� ���������";
            �heckSumDLL obj = new �heckSumDLL("JHMCM56557C404453");
            string result = obj.Examination�heckSum();
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// ��������, ��� ����������� ����� �� ��������� (JHMCM56577C404453)
        /// </summary> 
        [TestMethod]
        public void Examination�heckSum_�heckObjJHMCM56577C404453_CHKNotMatchesReturned()
        {
            string expected = "����������� ����� �� ���������";
            �heckSumDLL obj = new �heckSumDLL("JHMCM56577C404453");
            string result = obj.Examination�heckSum();
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// ��������, ��� ����������� ����� ������������ (JHMCM565M7C404453)
        /// </summary> 
        [TestMethod]
        public void Examination�heckSum_�heckObjJHMCM565M7C404453_CHKNotMatchesReturned()
        {
            string expected = "����� ����������� ����� � ������� 9 ������� �����������!";
            �heckSumDLL obj = new �heckSumDLL("JHMCM565M7C404453");
            string result = obj.Examination�heckSum();
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// ��������, ��� ������ ������� ����������� (JHMCMI55Q7C404453)
        /// </summary> 
        [TestMethod]
        public void Examination�heckSum_�heckObjJHMCMI55Q7C404453_IncorrectlyReturned()
        {
            string expected = "������ ������� �����������!";
            �heckSumDLL obj = new �heckSumDLL("JHMCMI55Q7C404453");
            string result = obj.Examination�heckSum();
            Assert.AreEqual(expected, result);
        }
    }
}