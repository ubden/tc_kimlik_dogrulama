#tckimlik T.C. Kimlik Doğrulama
        private static string[] TcKimlikExceptions = new string[] { "11111111110", "22222222220", "33333333330", "44444444440", "55555555550", "66666666660", "77777777770", "88888888880", "99999999990" };
        public static bool TcKimlikDogrula(string tcKimlikNo) => TcKimlikDogrulaV1(tcKimlikNo) || TcKimlikDogrulaV2(tcKimlikNo);
        private static bool TcKimlikDogrulaV1(string tcKimlikNo)
        {
            if (tcKimlikNo.Length != 11 || TcKimlikExceptions.Any(tc => tc == tcKimlikNo)) return false;
            int tekBasamakToplam = 0, ciftBasamakToplam = 0, tekilHesap, toplam = 0;
            for (int i = 0; i < 9; i += 2)
                tekBasamakToplam += int.Parse(tcKimlikNo.Substring(i, 1));
            for (int i = 1; i < 9; i += 2)
                ciftBasamakToplam += int.Parse(tcKimlikNo.Substring(i, 1));
            tekilHesap = ((tekBasamakToplam * 7) - ciftBasamakToplam) % 10;
            for (int i = 0; i < 10; i++)
            {
                byte toplanacakSayi = byte.Parse(tcKimlikNo.Substring(i, 1));
                toplam += toplanacakSayi;
                toplam %= 10;
            }
            tcKimlikNo += Convert.ToInt32(toplam);
            return tekilHesap.ToString() == tcKimlikNo.Substring(9, 1) && toplam.ToString() == tcKimlikNo.Substring(10, 1);
        }
        private static bool TcKimlikDogrulaV2(string tcKimlikNo)
        {
            bool returnvalue = false;
            if (tcKimlikNo.Length == 11 && !TcKimlikExceptions.Any(tc => tc == tcKimlikNo))
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;
                TcNo = Int64.Parse(tcKimlikNo);
                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;
                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);
                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }
        #teckimlik
