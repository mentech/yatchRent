
var SelectedDates = {};

SelectedDates[new Date("01/01/2017")] = "YILBAŞI",
    SelectedDates[new Date("04/23/2017")] = "ULUSAL EGEMENLİK VE ÇOCUK BAYRAMI",
    SelectedDates[new Date("05/01/2017")] = "EMEK VE DAYANIŞMA GÜNÜ",
    SelectedDates[new Date("05/19/2017")] = "ATATÜRK'Ü ANMA GENÇLİK VE SPOR BAYRAMI",
    SelectedDates[new Date("06/25/2017")] = "RAMAZAN BAYRAMI 1.GÜN",
    SelectedDates[new Date("06/26/2017")] = "RAMAZAN BAYRAMI 2.GÜN",
    SelectedDates[new Date("06/27/2017")] = "RAMAZAN BAYRAMI 3.GÜN",
    SelectedDates[new Date("08/30/2017")] = "ZAFER BAYRAMI",
    SelectedDates[new Date("09/01/2017")] = "KURBAN BAYRAMI 1.GÜN",
    SelectedDates[new Date("09/02/2017")] = "KURBAN BAYRAMI 2.GÜN",
    SelectedDates[new Date("09/03/2017")] = "KURBAN BAYRAMI 3.GÜN",
    SelectedDates[new Date("09/04/2017")] = "KURBAN BAYRAMI 4.GÜN",
    SelectedDates[new Date("10/29/2017")] = "CUMHURİYET BAYRAMI",
    SelectedDates[new Date("01/01/2018")] = "YILBAŞI",
    SelectedDates[new Date("04/23/2018")] = "ULUSAL EGEMENLİK VE ÇOCUK BAYRAMI",
    SelectedDates[new Date("05/01/2018")] = "EMEK VE DAYANIŞMA GÜNÜ",
    SelectedDates[new Date("05/19/2018")] = "ATATÜRK'Ü ANMA GENÇLİK VE SPOR BAYRAMI",
    SelectedDates[new Date("06/15/2018")] = "RAMAZAN BAYRAMI 1.GÜN",
    SelectedDates[new Date("06/16/2018")] = "RAMAZAN BAYRAMI 2.GÜN",
    SelectedDates[new Date("06/17/2018")] = "RAMAZAN BAYRAMI 3.GÜN",
    SelectedDates[new Date("08/30/2018")] = "ZAFER BAYRAMI",
    SelectedDates[new Date("08/21/2018")] = "KURBAN BAYRAMI 1.GÜN",
    SelectedDates[new Date("08/22/2018")] = "KURBAN BAYRAMI 2.GÜN",
    SelectedDates[new Date("08/23/2018")] = "KURBAN BAYRAMI 3.GÜN",
    SelectedDates[new Date("08/24/2018")] = "KURBAN BAYRAMI 4.GÜN",
    SelectedDates[new Date("10/29/2018")] = "CUMHURİYET BAYRAMI",
    SelectedDates[new Date("01/01/2019")] = "YILBAŞI",
    SelectedDates[new Date("04/23/2019")] = "ULUSAL EGEMENLİK VE ÇOCUK BAYRAMI",
    SelectedDates[new Date("05/01/2019")] = "EMEK VE DAYANIŞMA GÜNÜ",
    SelectedDates[new Date("05/19/2019")] = "ATATÜRK'Ü ANMA GENÇLİK VE SPOR BAYRAMI",
    SelectedDates[new Date("06/05/2019")] = "RAMAZAN BAYRAMI 1.GÜN",
    SelectedDates[new Date("06/06/2019")] = "RAMAZAN BAYRAMI 2.GÜN",
    SelectedDates[new Date("06/07/2019")] = "RAMAZAN BAYRAMI 3.GÜN",
    SelectedDates[new Date("08/30/2019")] = "ZAFER BAYRAMI",
    SelectedDates[new Date("08/11/2019")] = "KURBAN BAYRAMI 1.GÜN",
    SelectedDates[new Date("08/12/2019")] = "KURBAN BAYRAMI 2.GÜN",
    SelectedDates[new Date("08/13/2019")] = "KURBAN BAYRAMI 3.GÜN",
    SelectedDates[new Date("08/14/2019")] = "KURBAN BAYRAMI 4.GÜN",
    SelectedDates[new Date("10/29/2019")] = "CUMHURİYET BAYRAMI";


function ozelGunEkle(date) {
    if (SelectedDates[date] != undefined) {
        return {
            classes: 'activeClass',
            tooltip: SelectedDates[date]
        };
    }
    return;
}



$(".rezTarih").datepicker({
    format: 'dd.mm.yyyy',
    startDate: '0d',
    todayBtn: 'linked',
    language: 'tr',
    autoclose: true,
    orientation: "bottom",
    todayHighlight: true,
    beforeShowDay: ozelGunEkle
    
});

