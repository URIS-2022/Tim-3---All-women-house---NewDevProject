namespace IT64_2019_URIS_CustomerRegistration.Models
{
    public class CustomerAddDto
    {
        /// <summary>
        /// Lice je polje u koje je potrebno unijeti da li je lice fizicko ili pravno.
        /// </summary>
        public string? Person { get; set; }

        /// <summary>
        /// Ostvarena povrsina koju je kupac zakupio u toku nadmetanja.
        /// </summary>
        public int RealizedArea { get; set; }

        /// <summary>
        /// Ovlascena osoba
        /// </summary>
        public string? AuthorizedPerson { get; set; }

        /// <summary>
        /// Uplata
        /// </summary>
        public double Payments { get; set; }
        /// <summary>
        /// Prioritet moze da bude:
        /// 1. Vlasnik sistema za navodnjavanje.
        /// 2. Vlasnik zemljista koje se granici sa zemljistem koje se daje u zakup.
        /// 3. Poljoprivrednik koji je upisan u Registar.
        /// 4. Vlasnik zemljista koje je najblize zemljistu koje se daje u zakup.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Tip garancije moze biti:
        /// 1. Jamstvo
        /// 2. Bankarska Garancija
        /// 3. Zirantska
        /// 4. Uplata gotovinom
        /// </summary>
        public string? Guarantor { get; set; }

        public Guid RegistrationFormId { get; set; }


    }
}
