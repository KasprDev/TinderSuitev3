using TinderSuitev3.Objects;

namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ViewProfileDto
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("results")]
        public TinderUser Results { get; set; }
    }

    public partial class Badge
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Job
    {
        [JsonProperty("company")]
        public City Company { get; set; }

        [JsonProperty("title")]
        public City Title { get; set; }
    }

    public partial class MatchedPreferences
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("names")]
        public string[] Names { get; set; }

        [JsonProperty("has_bio")]
        public bool HasBio { get; set; }
    }

    public partial class Photo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("crop_info")]
        public CropInfo CropInfo { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("processedFiles")]
        public ProcessedFile[] ProcessedFiles { get; set; }

        [JsonProperty("processedVideos")]
        public object[] ProcessedVideos { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("assets")]
        public Asset[] Assets { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }
    }

    public partial class Asset
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class CropInfo
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("algo")]
        public Algo Algo { get; set; }

        [JsonProperty("processed_by_bullseye")]
        public bool ProcessedByBullseye { get; set; }

        [JsonProperty("user_customized")]
        public bool UserCustomized { get; set; }

        [JsonProperty("faces")]
        public Face[] Faces { get; set; }
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

    public partial class Face
    {
        [JsonProperty("algo")]
        public Algo Algo { get; set; }

        [JsonProperty("bounding_box_percentage")]
        public double BoundingBoxPercentage { get; set; }
    }

    public partial class User
    {
        [JsonProperty("width_pct")]
        public long WidthPct { get; set; }

        [JsonProperty("x_offset_pct")]
        public long XOffsetPct { get; set; }

        [JsonProperty("height_pct")]
        public double HeightPct { get; set; }

        [JsonProperty("y_offset_pct")]
        public double YOffsetPct { get; set; }
    }

    public partial class ProcessedFile
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class RelationshipIntent
    {
        [JsonProperty("descriptor_choice_id")]
        public string DescriptorChoiceId { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("title_text")]
        public string TitleText { get; set; }

        [JsonProperty("body_text")]
        public string BodyText { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonProperty("hidden_intent")]
        public HiddenIntent HiddenIntent { get; set; }

        [JsonProperty("tapped_action")]
        public TappedAction TappedAction { get; set; }
    }

    public partial class HiddenIntent
    {
        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("title_text")]
        public string TitleText { get; set; }

        [JsonProperty("body_text")]
        public string BodyText { get; set; }
    }

    public partial class TappedAction
    {
        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("query_params")]
        public QueryParams QueryParams { get; set; }
    }

    public partial class QueryParams
    {
        [JsonProperty("component_id")]
        public string ComponentId { get; set; }
    }

    public partial class SelectedDescriptor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("icon_urls")]
        public IconUrl[] IconUrls { get; set; }

        [JsonProperty("choice_selections", NullValueHandling = NullValueHandling.Ignore)]
        public Artist[] ChoiceSelections { get; set; }

        [JsonProperty("section_id")]
        public string SectionId { get; set; }

        [JsonProperty("section_name")]
        public string SectionName { get; set; }

        [JsonProperty("measurable_selection", NullValueHandling = NullValueHandling.Ignore)]
        public MeasurableSelection MeasurableSelection { get; set; }
    }

    public partial class Artist
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class IconUrl
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

        [JsonProperty("min")]
        public long Min { get; set; }

        [JsonProperty("max")]
        public long Max { get; set; }

        [JsonProperty("unit_of_measure")]
        public string UnitOfMeasure { get; set; }
    }

    public partial class SpotifyThemeTrack
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("artists")]
        public Artist[] Artists { get; set; }

        [JsonProperty("preview_url")]
        public Uri PreviewUrl { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public partial class Album
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Teaser
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("string")]
        public string String { get; set; }
    }

    public partial class UserInterests
    {
        [JsonProperty("selected_interests")]
        public Artist[] SelectedInterests { get; set; }
    }
}
