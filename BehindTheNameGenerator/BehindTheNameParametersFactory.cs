using System.Collections.Generic;
using System.Linq;

namespace BehindTheNameGenerator
{
    public class BehindTheNameParametersFactory : IParametersFactory
    {
        public string Factory()
        {
            var parameters = _parameters.Select(item => $"{item.Key}={item.Value}");
            var joinedParameters = string.Join("&", parameters);
            return joinedParameters;
        }

        public BehindTheNameParametersFactory SelectAll()
        {
            var propertyInfos = GetType().GetProperties()
                .Where(item => item.PropertyType == typeof(bool));
            foreach (var propertyInfo in propertyInfos)
                propertyInfo.SetValue(this, true, null);
            return this;
        }

        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        private int _number;

        private Gender _gender;
        private bool _african;
        private bool _albanian;
        private bool _arabic;
        private bool _armenian;
        private bool _azerbaijani;
        private bool _basque;
        private bool _breton;
        private bool _bulgarian;
        private bool _catalan;
        private bool _chinese;
        private bool _croatian;
        private bool _czech;
        private bool _danish;
        private bool _dutch;
        private bool _english;
        private bool _esperanto;
        private bool _estonian;
        private bool _finnish;
        private bool _french;
        private bool _frisian;
        private bool _galician;
        private bool _georgian;
        private bool _german;
        private bool _greek;
        private bool _hawaiian;
        private bool _hungarian;
        private bool _icelandic;
        private bool _igbo;
        private bool _indian;
        private bool _indonesian;
        private bool _irish;
        private bool _italian;
        private bool _japanese;
        private bool _jewish;
        private bool _kazakh;
        private bool _khmer;
        private bool _korean;
        private bool _latvian;
        private bool _limburgish;
        private bool _lithuanian;
        private bool _macedonian;
        private bool _maori;
        private bool _nativeAmerican;
        private bool _norwegian;
        private bool _occitan;
        private bool _pakistani;
        private bool _persian;
        private bool _polish;
        private bool _portuguese;
        private bool _romanian;
        private bool _russian;
        private bool _scottish;
        private bool _serbian;
        private bool _slovak;
        private bool _slovene;
        private bool _spanish;
        private bool _swedish;
        private bool _thai;
        private bool _turkish;
        private bool _ukrainian;
        private bool _vietnamese;
        private bool _welsh;
        private bool _yoruba;
        private bool _mythology;
        private bool _greekMyth;
        private bool _romanMyth;
        private bool _celticMyth;
        private bool _norseMyth;
        private bool _hinduism;
        private bool _ancient;
        private bool _classicalGreek;
        private bool _classicalRoman;
        private bool _ancientCeltic;
        private bool _germanic;
        private bool _angloSaxon;
        private bool _norse;
        private bool _biblical;
        private bool _history;
        private bool _literature;
        private bool _theology;
        private bool _fairy;
        private bool _goth;
        private bool _hillbilly;
        private bool _hippy;
        private bool _kreatyve;
        private bool _rapper;
        private bool _transformer;
        private bool _witch;
        private bool _wrestler;
        private bool _fantasy;
        private bool _gluttakh;
        private bool _monstrall;
        private bool _romanto;
        private bool _simitiq;
        private bool _tsang;
        private bool _xalaxxi;

        private static string BoolToIntChar(bool b) => b ? "1" : "0";

        public int Number { set { _parameters["number"] = value.ToString(); _number = value; } get => _number; }
        public Gender Gender
        {
            set
            {
                _parameters["gender"] = value == Gender.Female ? "f" : value == Gender.Male ? "m" : "both";
                _gender = value;
            }
            get => _gender;
        }
        public bool African { set { _parameters["usage_afr"] = BoolToIntChar(value); _african = value; } get => _african; }
        public bool Albanian { set { _parameters["usage_alb"] = BoolToIntChar(value); _albanian = value; } get => _albanian; }
        public bool Arabic { set { _parameters["usage_ara"] = BoolToIntChar(value); _arabic = value; } get => _arabic; }
        public bool Armenian { set { _parameters["usage_arm"] = BoolToIntChar(value); _armenian = value; } get => _armenian; }
        public bool Azerbaijani { set { _parameters["usage_aze"] = BoolToIntChar(value); _azerbaijani = value; } get => _azerbaijani; }
        public bool Basque { set { _parameters["usage_bas"] = BoolToIntChar(value); _basque = value; } get => _basque; }
        public bool Breton { set { _parameters["usage_bre"] = BoolToIntChar(value); _breton = value; } get => _breton; }
        public bool Bulgarian { set { _parameters["usage_bul"] = BoolToIntChar(value); _bulgarian = value; } get => _bulgarian; }
        public bool Catalan { set { _parameters["usage_cat"] = BoolToIntChar(value); _catalan = value; } get => _catalan; }
        public bool Chinese { set { _parameters["usage_chi"] = BoolToIntChar(value); _chinese = value; } get => _chinese; }
        public bool Croatian { set { _parameters["usage_cro"] = BoolToIntChar(value); _croatian = value; } get => _croatian; }
        public bool Czech { set { _parameters["usage_cze"] = BoolToIntChar(value); _czech = value; } get => _czech; }
        public bool Danish { set { _parameters["usage_dan"] = BoolToIntChar(value); _danish = value; } get => _danish; }
        public bool Dutch { set { _parameters["usage_dut"] = BoolToIntChar(value); _dutch = value; } get => _dutch; }
        public bool English { set { _parameters["usage_eng"] = BoolToIntChar(value); _english = value; } get => _english; }
        public bool Esperanto { set { _parameters["usage_esp"] = BoolToIntChar(value); _esperanto = value; } get => _esperanto; }
        public bool Estonian { set { _parameters["usage_est"] = BoolToIntChar(value); _estonian = value; } get => _estonian; }
        public bool Finnish { set { _parameters["usage_fin"] = BoolToIntChar(value); _finnish = value; } get => _finnish; }
        public bool French { set { _parameters["usage_fre"] = BoolToIntChar(value); _french = value; } get => _french; }
        public bool Frisian { set { _parameters["usage_fri"] = BoolToIntChar(value); _frisian = value; } get => _frisian; }
        public bool Galician { set { _parameters["usage_gal"] = BoolToIntChar(value); _galician = value; } get => _galician; }
        public bool Georgian { set { _parameters["usage_geo"] = BoolToIntChar(value); _georgian = value; } get => _georgian; }
        public bool German { set { _parameters["usage_ger"] = BoolToIntChar(value); _german = value; } get => _german; }
        public bool Greek { set { _parameters["usage_gre"] = BoolToIntChar(value); _greek = value; } get => _greek; }
        public bool Hawaiian { set { _parameters["usage_haw"] = BoolToIntChar(value); _hawaiian = value; } get => _hawaiian; }
        public bool Hungarian { set { _parameters["usage_hun"] = BoolToIntChar(value); _hungarian = value; } get => _hungarian; }
        public bool Icelandic { set { _parameters["usage_ice"] = BoolToIntChar(value); _icelandic = value; } get => _icelandic; }
        public bool Igbo { set { _parameters["usage_igb"] = BoolToIntChar(value); _igbo = value; } get => _igbo; }
        public bool Indian { set { _parameters["usage_ind"] = BoolToIntChar(value); _indian = value; } get => _indian; }
        public bool Indonesian { set { _parameters["usage_ins"] = BoolToIntChar(value); _indonesian = value; } get => _indonesian; }
        public bool Irish { set { _parameters["usage_iri"] = BoolToIntChar(value); _irish = value; } get => _irish; }
        public bool Italian { set { _parameters["usage_ita"] = BoolToIntChar(value); _italian = value; } get => _italian; }
        public bool Japanese { set { _parameters["usage_jap"] = BoolToIntChar(value); _japanese = value; } get => _japanese; }
        public bool Jewish { set { _parameters["usage_jew"] = BoolToIntChar(value); _jewish = value; } get => _jewish; }
        public bool Kazakh { set { _parameters["usage_kaz"] = BoolToIntChar(value); _kazakh = value; } get => _kazakh; }
        public bool Khmer { set { _parameters["usage_khm"] = BoolToIntChar(value); _khmer = value; } get => _khmer; }
        public bool Korean { set { _parameters["usage_kor"] = BoolToIntChar(value); _korean = value; } get => _korean; }
        public bool Latvian { set { _parameters["usage_lat"] = BoolToIntChar(value); _latvian = value; } get => _latvian; }
        public bool Limburgish { set { _parameters["usage_lim"] = BoolToIntChar(value); _limburgish = value; } get => _limburgish; }
        public bool Lithuanian { set { _parameters["usage_lth"] = BoolToIntChar(value); _lithuanian = value; } get => _lithuanian; }
        public bool Macedonian { set { _parameters["usage_mac"] = BoolToIntChar(value); _macedonian = value; } get => _macedonian; }
        public bool Maori { set { _parameters["usage_mao"] = BoolToIntChar(value); _maori = value; } get => _maori; }
        public bool NativeAmerican { set { _parameters["usage_ame"] = BoolToIntChar(value); _nativeAmerican = value; } get => _nativeAmerican; }
        public bool Norwegian { set { _parameters["usage_nor"] = BoolToIntChar(value); _norwegian = value; } get => _norwegian; }
        public bool Occitan { set { _parameters["usage_occ"] = BoolToIntChar(value); _occitan = value; } get => _occitan; }
        public bool Pakistani { set { _parameters["usage_pak"] = BoolToIntChar(value); _pakistani = value; } get => _pakistani; }
        public bool Persian { set { _parameters["usage_per"] = BoolToIntChar(value); _persian = value; } get => _persian; }
        public bool Polish { set { _parameters["usage_pol"] = BoolToIntChar(value); _polish = value; } get => _polish; }
        public bool Portuguese { set { _parameters["usage_por"] = BoolToIntChar(value); _portuguese = value; } get => _portuguese; }
        public bool Romanian { set { _parameters["usage_rmn"] = BoolToIntChar(value); _romanian = value; } get => _romanian; }
        public bool Russian { set { _parameters["usage_rus"] = BoolToIntChar(value); _russian = value; } get => _russian; }
        public bool Scottish { set { _parameters["usage_sco"] = BoolToIntChar(value); _scottish = value; } get => _scottish; }
        public bool Serbian { set { _parameters["usage_ser"] = BoolToIntChar(value); _serbian = value; } get => _serbian; }
        public bool Slovak { set { _parameters["usage_slk"] = BoolToIntChar(value); _slovak = value; } get => _slovak; }
        public bool Slovene { set { _parameters["usage_sln"] = BoolToIntChar(value); _slovene = value; } get => _slovene; }
        public bool Spanish { set { _parameters["usage_spa"] = BoolToIntChar(value); _spanish = value; } get => _spanish; }
        public bool Swedish { set { _parameters["usage_swe"] = BoolToIntChar(value); _swedish = value; } get => _swedish; }
        public bool Thai { set { _parameters["usage_tha"] = BoolToIntChar(value); _thai = value; } get => _thai; }
        public bool Turkish { set { _parameters["usage_tur"] = BoolToIntChar(value); _turkish = value; } get => _turkish; }
        public bool Ukrainian { set { _parameters["usage_ukr"] = BoolToIntChar(value); _ukrainian = value; } get => _ukrainian; }
        public bool Vietnamese { set { _parameters["usage_vie"] = BoolToIntChar(value); _vietnamese = value; } get => _vietnamese; }
        public bool Welsh { set { _parameters["usage_wel"] = BoolToIntChar(value); _welsh = value; } get => _welsh; }
        public bool Yoruba { set { _parameters["usage_yor"] = BoolToIntChar(value); _yoruba = value; } get => _yoruba; }
        public bool Mythology { set { _parameters["usage_myth"] = BoolToIntChar(value); _mythology = value; } get => _mythology; }
        public bool GreekMyth { set { _parameters["usage_grem"] = BoolToIntChar(value); _greekMyth = value; } get => _greekMyth; }
        public bool RomanMyth { set { _parameters["usage_romm"] = BoolToIntChar(value); _romanMyth = value; } get => _romanMyth; }
        public bool CelticMyth { set { _parameters["usage_celm"] = BoolToIntChar(value); _celticMyth = value; } get => _celticMyth; }
        public bool NorseMyth { set { _parameters["usage_scam"] = BoolToIntChar(value); _norseMyth = value; } get => _norseMyth; }
        public bool Hinduism { set { _parameters["usage_indm"] = BoolToIntChar(value); _hinduism = value; } get => _hinduism; }
        public bool Ancient { set { _parameters["usage_anci"] = BoolToIntChar(value); _ancient = value; } get => _ancient; }
        public bool ClassicalGreek { set { _parameters["usage_grea"] = BoolToIntChar(value); _classicalGreek = value; } get => _classicalGreek; }
        public bool ClassicalRoman { set { _parameters["usage_roma"] = BoolToIntChar(value); _classicalRoman = value; } get => _classicalRoman; }
        public bool AncientCeltic { set { _parameters["usage_cela"] = BoolToIntChar(value); _ancientCeltic = value; } get => _ancientCeltic; }
        public bool Germanic { set { _parameters["usage_gmca"] = BoolToIntChar(value); _germanic = value; } get => _germanic; }
        public bool AngloSaxon { set { _parameters["usage_enga"] = BoolToIntChar(value); _angloSaxon = value; } get => _angloSaxon; }
        public bool Norse { set { _parameters["usage_scaa"] = BoolToIntChar(value); _norse = value; } get => _norse; }
        public bool Biblical { set { _parameters["usage_bibl"] = BoolToIntChar(value); _biblical = value; } get => _biblical; }
        public bool History { set { _parameters["usage_hist"] = BoolToIntChar(value); _history = value; } get => _history; }
        public bool Literature { set { _parameters["usage_lite"] = BoolToIntChar(value); _literature = value; } get => _literature; }
        public bool Theology { set { _parameters["usage_theo"] = BoolToIntChar(value); _theology = value; } get => _theology; }
        public bool Fairy { set { _parameters["usage_fairy"] = BoolToIntChar(value); _fairy = value; } get => _fairy; }
        public bool Goth { set { _parameters["usage_goth"] = BoolToIntChar(value); _goth = value; } get => _goth; }
        public bool Hillbilly { set { _parameters["usage_hb"] = BoolToIntChar(value); _hillbilly = value; } get => _hillbilly; }
        public bool Hippy { set { _parameters["usage_hippy"] = BoolToIntChar(value); _hippy = value; } get => _hippy; }
        public bool Kreatyve { set { _parameters["usage_kk"] = BoolToIntChar(value); _kreatyve = value; } get => _kreatyve; }
        public bool Rapper { set { _parameters["usage_rap"] = BoolToIntChar(value); _rapper = value; } get => _rapper; }
        public bool Transformer { set { _parameters["usage_trans"] = BoolToIntChar(value); _transformer = value; } get => _transformer; }
        public bool Witch { set { _parameters["usage_witch"] = BoolToIntChar(value); _witch = value; } get => _witch; }
        public bool Wrestler { set { _parameters["usage_wrest"] = BoolToIntChar(value); _wrestler = value; } get => _wrestler; }
        public bool Fantasy { set { _parameters["usage_fntsy"] = BoolToIntChar(value); _fantasy = value; } get => _fantasy; }
        public bool Gluttakh { set { _parameters["usage_fntsg"] = BoolToIntChar(value); _gluttakh = value; } get => _gluttakh; }
        public bool Monstrall { set { _parameters["usage_fntsm"] = BoolToIntChar(value); _monstrall = value; } get => _monstrall; }
        public bool Romanto { set { _parameters["usage_fntsr"] = BoolToIntChar(value); _romanto = value; } get => _romanto; }
        public bool Simitiq { set { _parameters["usage_fntss"] = BoolToIntChar(value); _simitiq = value; } get => _simitiq; }
        public bool Tsang { set { _parameters["usage_fntst"] = BoolToIntChar(value); _tsang = value; } get => _tsang; }
        public bool Xalaxxi { set { _parameters["usage_fntsx"] = BoolToIntChar(value); _xalaxxi = value; } get => _xalaxxi; }
    }
}