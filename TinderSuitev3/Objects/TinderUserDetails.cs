using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public partial class TinderUserDetails
    {
        [JsonProperty("meta")]
        public TinderSuitev3.Objects.Meta Meta { get; set; }

        [JsonProperty("data")]
        public TinderUserDetailsData Data { get; set; }
    }

    public partial class TinderUserDetailsData
    {
        [JsonProperty("likes")]
        public Likes Likes { get; set; }

        [JsonProperty("offerings")]
        public Offerings Offerings { get; set; }

        [JsonProperty("plus_control")]
        public PlusControl PlusControl { get; set; }

        [JsonProperty("purchase")]
        public Purchase Purchase { get; set; }

        [JsonProperty("user")]
        public DataUser User { get; set; }

        [JsonProperty("misc_merchandising")]
        public MiscMerchandising MiscMerchandising { get; set; }
    }

    public partial class Likes
    {
        [JsonProperty("likes_remaining")]
        public long LikesRemaining { get; set; }
    }

    public partial class MiscMerchandising
    {
        [JsonProperty("subscription_card_ordering")]
        public string[] SubscriptionCardOrdering { get; set; }

        [JsonProperty("landing_card")]
        public string LandingCard { get; set; }

        [JsonProperty("controlla_carousel_ordering")]
        public string[] ControllaCarouselOrdering { get; set; }
    }

    public partial class Offerings
    {
        [JsonProperty("plus")]
        public Plus Plus { get; set; }

        [JsonProperty("gold")]
        public Gold Gold { get; set; }

        [JsonProperty("platinum")]
        public Platinum Platinum { get; set; }

        [JsonProperty("boost")]
        public OfferingsBoost Boost { get; set; }

        [JsonProperty("readreceipt")]
        public Primetimeboost Readreceipt { get; set; }

        [JsonProperty("superboost")]
        public Superboost Superboost { get; set; }

        [JsonProperty("superlike")]
        public OfferingsBoost Superlike { get; set; }

        [JsonProperty("primetimeboost")]
        public Primetimeboost Primetimeboost { get; set; }
    }

    public partial class OfferingsBoost
    {
        [JsonProperty("purchase_type")]
        public string PurchaseType { get; set; }

        [JsonProperty("product_data")]
        public BoostProductDatum[] ProductData { get; set; }

        [JsonProperty("merchandising")]
        public BoostMerchandising Merchandising { get; set; }
    }

    public partial class BoostMerchandising
    {
        [JsonProperty("upsell")]
        public string Upsell { get; set; }
    }

    public partial class BoostProductDatum
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("offer_type")]
        public string OfferType { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("payment_methods")]
        public PaymentMethod[] PaymentMethods { get; set; }
    }

    public partial class PaymentMethod
    {
        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("sku_id")]
        public string SkuId { get; set; }

        [JsonProperty("discount")]
        public double Discount { get; set; }

        [JsonProperty("require_zip")]
        public bool RequireZip { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("is_vat")]
        public bool IsVat { get; set; }

        [JsonProperty("tax_rate")]
        public long TaxRate { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public partial class Gold
    {
        [JsonProperty("purchase_type")]
        public string PurchaseType { get; set; }

        [JsonProperty("product_data")]
        public GoldProductDatum[] ProductData { get; set; }

        [JsonProperty("merchandising")]
        public GoldMerchandising Merchandising { get; set; }
    }

    public partial class GoldMerchandising
    {
        [JsonProperty("data")]
        public PurpleData Data { get; set; }

        [JsonProperty("ordering")]
        public Ordering Ordering { get; set; }

        [JsonProperty("sub_page_data")]
        public SubPageData SubPageData { get; set; }
    }

    public partial class PurpleData
    {
        [JsonProperty("superlike")]
        public ToppicksClass Superlike { get; set; }

        [JsonProperty("boost")]
        public ToppicksClass Boost { get; set; }

        [JsonProperty("hide_ads")]
        public Badge HideAds { get; set; }

        [JsonProperty("hide_age")]
        public Badge HideAge { get; set; }

        [JsonProperty("hide_distance")]
        public Badge HideDistance { get; set; }

        [JsonProperty("like")]
        public Badge Like { get; set; }

        [JsonProperty("control_who_sees_you")]
        public Badge ControlWhoSeesYou { get; set; }

        [JsonProperty("passport")]
        public Badge Passport { get; set; }

        [JsonProperty("rewind")]
        public Badge Rewind { get; set; }

        [JsonProperty("superboost_alc_access")]
        public Badge SuperboostAlcAccess { get; set; }

        [JsonProperty("control_who_you_see")]
        public Badge ControlWhoYouSee { get; set; }

        [JsonProperty("toppicks")]
        public ToppicksClass Toppicks { get; set; }

        [JsonProperty("toppicks_alc_access")]
        public Badge ToppicksAlcAccess { get; set; }

        [JsonProperty("likes_you")]
        public Badge LikesYou { get; set; }

        [JsonProperty("preference_filters")]
        public Badge PreferenceFilters { get; set; }
    }

    public partial class ToppicksClass
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("renewal_data")]
        public RenewalData RenewalData { get; set; }
    }

    public partial class RenewalData
    {
        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("refresh_interval")]
        public long RefreshInterval { get; set; }

        [JsonProperty("refresh_interval_unit")]
        public string RefreshIntervalUnit { get; set; }
    }

    public partial class Badge
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Ordering
    {
        [JsonProperty("carousel")]
        public string[] Carousel { get; set; }

        [JsonProperty("plus_screen")]
        public string[] PlusScreen { get; set; }
    }

    public partial class SubPageData
    {
        [JsonProperty("cta")]
        public string Cta { get; set; }

        [JsonProperty("termed")]
        public bool Termed { get; set; }

        [JsonProperty("sections")]
        public Section[] Sections { get; set; }
    }

    public partial class Section
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("benefits")]
        public Benefit[] Benefits { get; set; }
    }

    public partial class Benefit
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("included")]
        public bool Included { get; set; }

        [JsonProperty("deeplink")]
        public string Deeplink { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }

    public partial class GoldProductDatum
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("offer_type")]
        public string OfferType { get; set; }

        [JsonProperty("refresh_interval")]
        public long RefreshInterval { get; set; }

        [JsonProperty("refresh_interval_unit")]
        public string RefreshIntervalUnit { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("payment_methods")]
        public PaymentMethod[] PaymentMethods { get; set; }
    }

    public partial class Platinum
    {
        [JsonProperty("purchase_type")]
        public string PurchaseType { get; set; }

        [JsonProperty("product_data")]
        public GoldProductDatum[] ProductData { get; set; }

        [JsonProperty("merchandising")]
        public PlatinumMerchandising Merchandising { get; set; }
    }

    public partial class PlatinumMerchandising
    {
        [JsonProperty("data")]
        public FluffyData Data { get; set; }

        [JsonProperty("ordering")]
        public Ordering Ordering { get; set; }

        [JsonProperty("sub_page_data")]
        public SubPageData SubPageData { get; set; }
    }

    public partial class FluffyData
    {
        [JsonProperty("superlike")]
        public ToppicksClass Superlike { get; set; }

        [JsonProperty("boost")]
        public ToppicksClass Boost { get; set; }

        [JsonProperty("hide_ads")]
        public Badge HideAds { get; set; }

        [JsonProperty("hide_age")]
        public Badge HideAge { get; set; }

        [JsonProperty("hide_distance")]
        public Badge HideDistance { get; set; }

        [JsonProperty("like")]
        public Badge Like { get; set; }

        [JsonProperty("control_who_sees_you")]
        public Badge ControlWhoSeesYou { get; set; }

        [JsonProperty("passport")]
        public Badge Passport { get; set; }

        [JsonProperty("rewind")]
        public Badge Rewind { get; set; }

        [JsonProperty("superboost_alc_access")]
        public Badge SuperboostAlcAccess { get; set; }

        [JsonProperty("control_who_you_see")]
        public Badge ControlWhoYouSee { get; set; }

        [JsonProperty("toppicks")]
        public ToppicksClass Toppicks { get; set; }

        [JsonProperty("toppicks_alc_access")]
        public Badge ToppicksAlcAccess { get; set; }

        [JsonProperty("likes_you")]
        public Badge LikesYou { get; set; }

        [JsonProperty("superlike_attach_message")]
        public Badge SuperlikeAttachMessage { get; set; }

        [JsonProperty("my_likes_lookback")]
        public MyLikesLookback MyLikesLookback { get; set; }

        [JsonProperty("priority_likes")]
        public Badge PriorityLikes { get; set; }

        [JsonProperty("preference_filters")]
        public Badge PreferenceFilters { get; set; }
    }

    public partial class MyLikesLookback
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }
    }

    public partial class Plus
    {
        [JsonProperty("purchase_type")]
        public string PurchaseType { get; set; }

        [JsonProperty("product_data")]
        public GoldProductDatum[] ProductData { get; set; }

        [JsonProperty("merchandising")]
        public PlusMerchandising Merchandising { get; set; }
    }

    public partial class PlusMerchandising
    {
        [JsonProperty("data")]
        public TentacledData Data { get; set; }

        [JsonProperty("ordering")]
        public Ordering Ordering { get; set; }

        [JsonProperty("sub_page_data")]
        public SubPageData SubPageData { get; set; }
    }

    public partial class TentacledData
    {
        [JsonProperty("hide_ads")]
        public Badge HideAds { get; set; }

        [JsonProperty("hide_age")]
        public Badge HideAge { get; set; }

        [JsonProperty("hide_distance")]
        public Badge HideDistance { get; set; }

        [JsonProperty("like")]
        public Badge Like { get; set; }

        [JsonProperty("control_who_sees_you")]
        public Badge ControlWhoSeesYou { get; set; }

        [JsonProperty("passport")]
        public Badge Passport { get; set; }

        [JsonProperty("rewind")]
        public Badge Rewind { get; set; }

        [JsonProperty("superboost_alc_access")]
        public Badge SuperboostAlcAccess { get; set; }

        [JsonProperty("control_who_you_see")]
        public Badge ControlWhoYouSee { get; set; }
    }

    public partial class Primetimeboost
    {
        [JsonProperty("purchase_type")]
        public string PurchaseType { get; set; }

        [JsonProperty("product_data")]
        public BoostProductDatum[] ProductData { get; set; }

        [JsonProperty("merchandising")]
        public PlusControl Merchandising { get; set; }
    }

    public partial class PlusControl
    {
    }

    public partial class Superboost
    {
        [JsonProperty("purchase_type")]
        public string PurchaseType { get; set; }

        [JsonProperty("product_data")]
        public SuperboostProductDatum[] ProductData { get; set; }

        [JsonProperty("merchandising")]
        public PlusControl Merchandising { get; set; }
    }

    public partial class SuperboostProductDatum
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("offer_type")]
        public string OfferType { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("payment_methods")]
        public PaymentMethod[] PaymentMethods { get; set; }
    }

    public partial class Paywall
    {
        [JsonProperty("instanceID")]
        public string InstanceId { get; set; }

        [JsonProperty("templateID")]
        public string TemplateId { get; set; }

        [JsonProperty("productType")]
        public string ProductType { get; set; }

        [JsonProperty("entryPoint")]
        public string EntryPoint { get; set; }

        [JsonProperty("carouselSubscriptionV2", NullValueHandling = NullValueHandling.Ignore)]
        public CarouselSubscriptionV2 CarouselSubscriptionV2 { get; set; }

        [JsonProperty("carouselB", NullValueHandling = NullValueHandling.Ignore)]
        public CarouselB CarouselB { get; set; }
    }

    public partial class CarouselB
    {
        [JsonProperty("heroImage")]
        public HeroImage HeroImage { get; set; }

        [JsonProperty("upsellPrimary")]
        public UpsellPrimary UpsellPrimary { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("discountTag")]
        public string DiscountTag { get; set; }
    }

    public partial class HeroImage
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class UpsellPrimary
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("productType")]
        public string ProductType { get; set; }

        [JsonProperty("deeplink")]
        public string Deeplink { get; set; }

        [JsonProperty("headerBackgroundColor")]
        public string HeaderBackgroundColor { get; set; }

        [JsonProperty("borderColor")]
        public string BorderColor { get; set; }

        [JsonProperty("button")]
        public UpsellPrimaryButton Button { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }
    }

    public partial class UpsellPrimaryButton
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("background")]
        public PurpleBackground Background { get; set; }

        [JsonProperty("borderColor")]
        public string BorderColor { get; set; }
    }

    public partial class PurpleBackground
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }

    public partial class CarouselSubscriptionV2
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("disclosureText")]
        public string DisclosureText { get; set; }

        [JsonProperty("allotmentDisclosure", NullValueHandling = NullValueHandling.Ignore)]
        public AllotmentDisclosure AllotmentDisclosure { get; set; }

        [JsonProperty("discountTag")]
        public string DiscountTag { get; set; }

        [JsonProperty("skuCard")]
        public SkuCard SkuCard { get; set; }

        [JsonProperty("button")]
        public CarouselSubscriptionV2Button Button { get; set; }
    }

    public partial class AllotmentDisclosure
    {
        [JsonProperty("boost")]
        public AllotmentDisclosureBoost Boost { get; set; }
    }

    public partial class AllotmentDisclosureBoost
    {
        [JsonProperty("weeklySub")]
        public string WeeklySub { get; set; }
    }

    public partial class CarouselSubscriptionV2Button
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("textColor")]
        public TextColorClass TextColor { get; set; }

        [JsonProperty("background")]
        public TextColorClass Background { get; set; }
    }

    public partial class TextColorClass
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fallback")]
        public string Fallback { get; set; }
    }

    public partial class Header
    {
        [JsonProperty("background")]
        public TextColorClass Background { get; set; }

        [JsonProperty("iconUrl")]
        public NewSubClass IconUrl { get; set; }
    }

    public partial class NewSubClass
    {
        [JsonProperty("default")]
        public Uri Default { get; set; }

        [JsonProperty("dark")]
        public Uri Dark { get; set; }
    }

    public partial class SkuCard
    {
        [JsonProperty("borderColor")]
        public BorderColor BorderColor { get; set; }

        [JsonProperty("merchandisingTextColor")]
        public TextColorClass MerchandisingTextColor { get; set; }

        [JsonProperty("iconUrl")]
        public IconUrl IconUrl { get; set; }
    }

    public partial class BorderColor
    {
        [JsonProperty("selected")]
        public TextColorClass Selected { get; set; }

        [JsonProperty("unselected")]
        public TextColorClass Unselected { get; set; }
    }

    public partial class IconUrl
    {
        [JsonProperty("newSub")]
        public NewSubClass NewSub { get; set; }

        [JsonProperty("upgrade")]
        public NewSubClass Upgrade { get; set; }
    }

    public partial class Title
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("text")]
        public Text Text { get; set; }

        [JsonProperty("textColor")]
        public TextColorClass TextColor { get; set; }
    }

    public partial class Text
    {
        [JsonProperty("default")]
        public string Default { get; set; }

        [JsonProperty("preference_filters", NullValueHandling = NullValueHandling.Ignore)]
        public string PreferenceFilters { get; set; }

        [JsonProperty("like", NullValueHandling = NullValueHandling.Ignore)]
        public string Like { get; set; }

        [JsonProperty("likes_you", NullValueHandling = NullValueHandling.Ignore)]
        public string LikesYou { get; set; }

        [JsonProperty("boost", NullValueHandling = NullValueHandling.Ignore)]
        public string Boost { get; set; }

        [JsonProperty("hide_age_and_distance", NullValueHandling = NullValueHandling.Ignore)]
        public string HideAgeAndDistance { get; set; }

        [JsonProperty("control_who_sees_you", NullValueHandling = NullValueHandling.Ignore)]
        public string ControlWhoSeesYou { get; set; }

        [JsonProperty("passport", NullValueHandling = NullValueHandling.Ignore)]
        public string Passport { get; set; }

        [JsonProperty("superlike", NullValueHandling = NullValueHandling.Ignore)]
        public string Superlike { get; set; }

        [JsonProperty("rewind", NullValueHandling = NullValueHandling.Ignore)]
        public string Rewind { get; set; }

        [JsonProperty("hide_ads", NullValueHandling = NullValueHandling.Ignore)]
        public string HideAds { get; set; }

        [JsonProperty("toppicks", NullValueHandling = NullValueHandling.Ignore)]
        public string Toppicks { get; set; }

        [JsonProperty("likes_you_filtering", NullValueHandling = NullValueHandling.Ignore)]
        public string LikesYouFiltering { get; set; }

        [JsonProperty("superlike_attach_message", NullValueHandling = NullValueHandling.Ignore)]
        public string SuperlikeAttachMessage { get; set; }

        [JsonProperty("priority_likes", NullValueHandling = NullValueHandling.Ignore)]
        public string PriorityLikes { get; set; }

        [JsonProperty("my_type", NullValueHandling = NullValueHandling.Ignore)]
        public string MyType { get; set; }
    }

    public partial class Purchase
    {
        [JsonProperty("purchases")]
        public object[] Purchases { get; set; }

        [JsonProperty("subscription_expired")]
        public bool SubscriptionExpired { get; set; }

        [JsonProperty("payment_state")]
        public long PaymentState { get; set; }
    }

    public partial class DataUser
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("age_filter_max")]
        public long AgeFilterMax { get; set; }

        [JsonProperty("age_filter_min")]
        public long AgeFilterMin { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("birth_date")]
        public string BirthDate { get; set; }

        [JsonProperty("create_date")]
        public string CreateDate { get; set; }

        [JsonProperty("crm_id")]
        public string CrmId { get; set; }

        [JsonProperty("pos_info")]
        public PosInfo PosInfo { get; set; }

        [JsonProperty("discoverable")]
        public bool Discoverable { get; set; }

        [JsonProperty("distance_filter")]
        public long DistanceFilter { get; set; }

        [JsonProperty("auto_expansion")]
        public AutoExpansion AutoExpansion { get; set; }

        [JsonProperty("gender")]
        public long Gender { get; set; }

        [JsonProperty("all_in_gender")]
        public AllInGender[] AllInGender { get; set; }

        [JsonProperty("gender_filter")]
        public long GenderFilter { get; set; }

        [JsonProperty("show_gender_on_profile")]
        public bool ShowGenderOnProfile { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photos")]
        public Photo[] Photos { get; set; }

        [JsonProperty("photos_processing")]
        public bool PhotosProcessing { get; set; }

        [JsonProperty("photo_optimizer_enabled")]
        public bool PhotoOptimizerEnabled { get; set; }

        [JsonProperty("ping_time")]
        public string PingTime { get; set; }

        [JsonProperty("jobs")]
        public Job[] Jobs { get; set; }

        [JsonProperty("schools")]
        public School[] Schools { get; set; }

        [JsonProperty("badges")]
        public Badge[] Badges { get; set; }

        [JsonProperty("phone_id")]
        public string PhoneId { get; set; }

        [JsonProperty("interested_in")]
        public long[] InterestedIn { get; set; }

        [JsonProperty("pos")]
        public Pos Pos { get; set; }

        [JsonProperty("billing_info")]
        public BillingInfo BillingInfo { get; set; }

        [JsonProperty("autoplay_video")]
        public string AutoplayVideo { get; set; }

        [JsonProperty("top_picks_discoverable")]
        public bool TopPicksDiscoverable { get; set; }

        [JsonProperty("photo_tagging_enabled")]
        public bool PhotoTaggingEnabled { get; set; }

        [JsonProperty("show_same_orientation_first")]
        public ShowSameOrientationFirst ShowSameOrientationFirst { get; set; }

        [JsonProperty("sexual_orientations")]
        public AllInGender[] SexualOrientations { get; set; }

        [JsonProperty("user_interests")]
        public UserInterests UserInterests { get; set; }

        [JsonProperty("recommended_sort_discoverable")]
        public bool RecommendedSortDiscoverable { get; set; }

        [JsonProperty("selfie_verification")]
        public string SelfieVerification { get; set; }

        [JsonProperty("noonlight_protected")]
        public bool NoonlightProtected { get; set; }

        [JsonProperty("sync_swipe_enabled")]
        public bool SyncSwipeEnabled { get; set; }

        [JsonProperty("sparks_quizzes")]
        public SparksQuizz[] SparksQuizzes { get; set; }

        [JsonProperty("selected_descriptors")]
        public SelectedDescriptor[] SelectedDescriptors { get; set; }

        [JsonProperty("preference_filters")]
        public PlusControl PreferenceFilters { get; set; }

        [JsonProperty("mm_enabled")]
        public bool MmEnabled { get; set; }

        [JsonProperty("user_prompts")]
        public UserPrompts UserPrompts { get; set; }
    }

    public partial class AllInGender
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class AutoExpansion
    {
        [JsonProperty("age_toggle")]
        public bool AgeToggle { get; set; }

        [JsonProperty("distance_toggle")]
        public bool DistanceToggle { get; set; }
    }

    public partial class BillingInfo
    {
        [JsonProperty("supported_payment_methods")]
        public string[] SupportedPaymentMethods { get; set; }
    }

    public partial class School
    {
        [JsonProperty("displayed")]
        public bool Displayed { get; set; }
    }

    public partial class Photo
    {
        [JsonProperty("crop_info")]
        public CropInfo CropInfo { get; set; }

        [JsonProperty("assets")]
        public object[] Assets { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("processedVideos", NullValueHandling = NullValueHandling.Ignore)]
        public ProcessedVideo[] ProcessedVideos { get; set; }
    }

    public partial class CropInfo
    {
        [JsonProperty("processed_by_bullseye")]
        public bool ProcessedByBullseye { get; set; }

        [JsonProperty("user_customized")]
        public bool UserCustomized { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public CropInfoUser User { get; set; }

        [JsonProperty("algo", NullValueHandling = NullValueHandling.Ignore)]
        public Algo Algo { get; set; }

        [JsonProperty("faces_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? FacesCount { get; set; }
    }

    public partial class Algo
    {
        [JsonProperty("width_pct")]
        public double WidthPct { get; set; }

        [JsonProperty("x_offset_pct")]
        public double XOffsetPct { get; set; }

        [JsonProperty("height_pct")]
        public double HeightPct { get; set; }

        [JsonProperty("y_offset_pct")]
        public double YOffsetPct { get; set; }
    }

    public partial class CropInfoUser
    {
        [JsonProperty("width_pct")]
        public long WidthPct { get; set; }

        [JsonProperty("x_offset_pct")]
        public long XOffsetPct { get; set; }

        [JsonProperty("height_pct")]
        public double HeightPct { get; set; }

        [JsonProperty("y_offset_pct")]
        public long YOffsetPct { get; set; }
    }

    public partial class ProcessedVideo
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class Pos
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public partial class PosInfo
    {
        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }

    public partial class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cc")]
        public string Cc { get; set; }

        [JsonProperty("alpha3")]
        public string Alpha3 { get; set; }
    }

    public partial class State
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public partial class SelectedDescriptor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("icon_urls")]
        public IconUrlElement[] IconUrls { get; set; }

        [JsonProperty("section_id")]
        public string SectionId { get; set; }

        [JsonProperty("section_name")]
        public string SectionName { get; set; }

        [JsonProperty("choice_selections", NullValueHandling = NullValueHandling.Ignore)]
        public ChoiceSelection[] ChoiceSelections { get; set; }

        [JsonProperty("measurable_selection", NullValueHandling = NullValueHandling.Ignore)]
        public MeasurableSelection MeasurableSelection { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class IconUrlElement
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("quality")]
        public string Quality { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class MeasurableSelection
    {
        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("unit_of_measure")]
        public string UnitOfMeasure { get; set; }
    }

    public partial class ShowSameOrientationFirst
    {
        [JsonProperty("checked")]
        public bool Checked { get; set; }

        [JsonProperty("should_show_option")]
        public bool ShouldShowOption { get; set; }
    }

    public partial class SparksQuizz
    {
        [JsonProperty("section_id")]
        public string SectionId { get; set; }

        [JsonProperty("section_name")]
        public string SectionName { get; set; }

        [JsonProperty("quizzes")]
        public Quiz[] Quizzes { get; set; }
    }

    public partial class Quiz
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("answer_details")]
        public object[] AnswerDetails { get; set; }

        [JsonProperty("answers")]
        public object[] Answers { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }
    }

    public partial class UserInterests
    {
        [JsonProperty("selected_interests")]
        public AllInGender[] SelectedInterests { get; set; }

        [JsonProperty("available_interests")]
        public AllInGender[] AvailableInterests { get; set; }

        [JsonProperty("min_interests")]
        public long MinInterests { get; set; }

        [JsonProperty("max_interests")]
        public long MaxInterests { get; set; }
    }

    public partial class UserPrompts
    {
        [JsonProperty("section_name")]
        public string SectionName { get; set; }

        [JsonProperty("max_prompts")]
        public long MaxPrompts { get; set; }

        [JsonProperty("prompts")]
        public Prompt[] Prompts { get; set; }
    }

    public partial class Prompt
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("question_text")]
        public string QuestionText { get; set; }

        [JsonProperty("answer_text")]
        public string AnswerText { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }
    }
}
