namespace LibraryDLL
{
    public class СheckSumDLL
    {
        public string? VIN;
        public СheckSumDLL(string VIN)
        {
            this.VIN = VIN;
        }

        /// <summary>
        /// Проверка контрольной суммы 
        /// </summary>
        /// <param name="args"></param>
        public string ExaminationСheckSum()
        {
            if (СheckingCorrectness())
            {
                if (СheckingCHK())
                {
                    if (СheckingCHKAndСheckSum())
                    {
                        return "Контрольная сумма совпадает";
                    }
                    else
                    {
                        return "Контрольная сумма не совпадает";
                    }
                }
                else
                {
                    return "Число контрольной суммы в позиции 9 введено некорректно!";
                }
            }
            else
            {
                return "Строка введена некорректно!";
            }
        }

        /// <summary>
        /// Проверка на корректность введенных данных
        /// </summary>
        /// <returns></returns>
        public bool СheckingCorrectness()
        {
            int count = 0;
            foreach (char symbol in VIN)
            {
                //В VIN разрешено использовать только цифры и буквы латинского алфавита за исключением I, O, Q 
                if ((symbol >= '0' && symbol <= '9') || (symbol >= 'A' && symbol <= 'Z' && symbol != 'I' && symbol != 'O' && symbol != 'Q'))
                {
                    count++;
                }
            }
            if (count == VIN.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка корректности CHK (число контрольной суммы)
        /// </summary>
        /// <returns></returns>
        public bool СheckingCHK()
        {
            //В 9-ой позиции (индекс 8) контрольной суммы допустимы следующие значения: числа 0...9 или X.
            if ((VIN[8] >= '0' && VIN[8] <= '9') || (VIN[8] == 'X'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Сравнение CHK с полученной контрольной суммой
        /// </summary>
        /// <returns></returns>
        public bool СheckingCHKAndСheckSum()
        {
            char CHK = СalculatingСheckSum(); //Считаем контрольную сумму numVIN
            return VIN[8] == CHK ? true : false; //Проверяем совпадает ли контрольная сумма
        }

        /// <summary>
        /// Подсчет контрольной суммы
        /// </summary>
        /// <returns></returns>
        public char СalculatingСheckSum()
        {
            int[] m = СonverterNum(); //конвертируем VIN в числа
            char CHK;
            //Складываем произведения каждого знака VIN на его "вес" без CHK (m[8])
            int sum1 = m[0] * 8 + m[1] * 7 + m[2] * 6 + m[3] * 5 +
                m[4] * 4 + m[5] * 3 + m[6] * 2 + m[7] * 10 +
                m[9] * 9 + m[10] * 8 + m[11] * 7 + m[12] * 6 +
                m[13] * 5 + m[14] * 4 + m[15] * 3 + m[16] * 2;
            //Вычисляем ближайшее наименьшее целое число, кратное 11:
            int multipleNum11 = sum1 / 11; //т.к. int должно быть целое
            int sum2 = multipleNum11 * 11;
            //Разницу между результатом sum1 и sum2 записывается в десятый знак VIN
            int CHKNum = sum1 - sum2;
            if (CHKNum == 10)
            {
                //Если CHK = 10, то в 9 позиции VIN записывается "X"(римская 10)
                CHK = 'X';
            }
            else
            {
                //Переводим число в символ
                CHK = (char)(CHKNum + '0');
            }
            return CHK; //Полученная контрольная сумма
        }

        /// <summary>
        /// Перевод VIN в массив цифр в соответствии с таблицей
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        public int[] СonverterNum()
        {
            //Перевод строки в массив цифр
            int[] numVIN = new int[VIN.Length];
            for (int i = 0; i < VIN.Length; i++)
            {
                if (VIN[i] >= '0' && VIN[i] <= '9')
                {
                    //Переводим в int, 48 = '0'
                    numVIN[i] = Convert.ToInt32(VIN[i]) - 48;
                }
                else
                {
                    numVIN[i] = GetNum(VIN[i]);
                }
            }
            return numVIN;
        }

        /// <summary>
        /// Подмена букв на цифры в соответствии с таблицей
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int GetNum(char c)
        {
            char[] symb = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 7, 9, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < symb.Length; i++)
            {
                if (symb[i] == c)
                {
                    return nums[i];
                }
            }
            return 0;
            //В исключительной ситуации возвращаем 0, но после проверки в ExaminationСheckSum такой ситуации не должно произойти
        }

    }
}