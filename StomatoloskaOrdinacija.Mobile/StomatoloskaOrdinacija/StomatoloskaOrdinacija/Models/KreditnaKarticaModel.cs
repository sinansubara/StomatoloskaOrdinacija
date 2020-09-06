using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace StomatoloskaOrdinacija.Models
{
    public class KreditnaKarticaModel
    {
        [JsonProperty("exp_month")]
        public long? ExpMonth { get; set; }
        [JsonProperty("exp_year")]
        public long? ExpYear { get; set; }
        [JsonProperty("number")]
        public string Broj { get; set; }
        [JsonProperty("address_city")]
        public string Grad { get; set; }
        [JsonProperty("address_country")]
        public string Drzava { get; set; }
        [JsonProperty("currency")]
        public string Valuta { get; set; }
        [JsonProperty("cvc")]
        public string Cvc { get; set; }
        [JsonProperty("name")]
        public string Ime { get; set; }
        [JsonProperty("metadata")]
        public object MetaData { get; set; }
        [JsonProperty("issuing_card")]
        public string IssuingCardId { get; set; }
    }
}
