import LegendItem from "./LegendItem";

const legendItems = [
    new LegendItem(
        "1000+",
        "#741f1f",
        (cases) => cases >= 1000,
        "white"
    ),
    new LegendItem(
        "500-999",
        "#9c2929",
        (cases) => cases >= 500 && cases < 1000,
        "white"
    ),
    new LegendItem(
        "200-499",
        "#c57f7f",
        (cases) => cases >= 200 && cases < 500,
        // "white"
    ),
    new LegendItem(
        "50-199",
        "#d8aaaa",
        (cases) => cases >= 50 && cases < 200,
        // "white"
    ),
    new LegendItem(
        "0-49",
        "#ebd4d4",
        (cases) => cases > 0 && cases < 49,
        // "white"
    ),
];

export default legendItems;