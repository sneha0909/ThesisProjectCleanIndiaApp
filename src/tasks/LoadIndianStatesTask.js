import papa from "papaparse";
import features from '../data/indiaStates.json';
import legendItems from "../entities/LegendItems";

class LoadIndianStatesTask {

    complaintsDataUrl = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTgVsemsKcRNhIRrKCUCGCno6hg_C-B_Wbx5bBRw_KlU9QEzrsO0XkqF0os4k4XWCzkglH1umYdEcdF/pub?output=csv";

    setState = null;
    mapStates = features;

    load = (setState) => {
        this.setState = setState;

        papa.parse(this.complaintsDataUrl, {
            download: true,
            header: true,
            complete: (result) => {
                console.log(result);
                this.#processComplaintsData(result.data);
            },
            });

    };

    #processComplaintsData = (complaintStates) => {
        for (let i = 0; i < this.mapStates.length; i++) {
            const mapState = this.mapStates[i];
            const complaintState = complaintStates.find(
                (complaintState) => mapState.properties.NAME_1 === complaintState.State_Name
            );

            mapState.properties.confirmed = 0;
            mapState.properties.confirmedText = "0";

            if (complaintState != null) {
                let confirmed = Number(complaintState.Confirmed);
                mapState.properties.confirmed = confirmed;
                mapState.properties.confirmedText = confirmed;

            }
            this.#setStateColor(mapState);
        }
        this.setState(this.mapStates);
    };

    #setStateColor = (mapState) => {
        const legendItem = legendItems.find((legendItem) => 
        legendItem.isFor(mapState.properties.confirmed)
        );

        if(legendItem != null){
             mapState.properties.color = legendItem.color;
        }
    };
}

export default LoadIndianStatesTask;