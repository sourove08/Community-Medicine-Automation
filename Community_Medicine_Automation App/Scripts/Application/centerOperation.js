$('#DiseaseId').change(function () {
    var diseaseId = $("#DiseaseId").val();
    if (diseaseId == "") {
        $("#MedicineId").empty();
        var option = "<option value=''>Select </option>";
        $("#MedicineId").append(option);
        return;
    }

    $.ajax({
        type: "POST",
        url: "http://localhost:49267/Center/GetAllMedicineByDisease",
        datatype: "Json",
        data: { diseaseId: $('#DiseaseId').val() },
        success: function (data) {
            $("#MedicineId").empty();
            $.each(data, function (index, value) {
                $('#MedicineId').append('<option value="' + value.Id + '">' + value.GenericName + '</option>');
            });
        }

    });
});

$('#btn_voterId_add').click(function() {
    var voterId = $('#VoterId').val();
    $.ajax({
        type: "POST",
        url: "http://localhost:49267/Center/GetPatientByVoterId",
        datatype: "Json",
        data: { voterId: $('#VoterId').val() },
        success: function(response) {
            //$('#Name').append('<input class="text-box-single-line" id="Name" name="Name" type="text" value="'+ response.Name+'">');
            //$('#Address').append('<input class="text-box-single-line" id="Address" name="Address" type="text" value="'+ response.Address+'">');
            //$('#Age').append('<input class="text-box-single-line" id="Age" name="Age" type="text" value="'+response.Age +'">');
            $("#PatientId").val(response.Id);
            $("#VoterId").val(response.VoterId);
            $("#Name").val(response.Name);
            $("#Address").val(response.Address);
            $("#Age").val(response.Age);
            $("#ServiceTime").val(response.ServiceGiven);
        },

        error: function(response) {
            console.log(response.message);

        }

    });
    
});






$("#btn_disease_add").click(function () {

    var diseaseDetail = GetDiseaseDetail();
    var index = $('#tbl_disease tr').length;
   
    var diseaseCell = "<td><input type='hidden' name='PatientDiseases[" + index + "].DiseaseId' value='" + diseaseDetail.diseaseId +"'/>" + diseaseDetail.diseaseName + "</td>";
    var medicineCell = "<td><input type='hidden' name='PatientDiseases[" + index + "].MedicineId' value='" + diseaseDetail.medicineId +"'/>" + diseaseDetail.medicineName + "</td>";
    var doseCell = "<td><input type='hidden' name='PatientDiseases[" + index + "].SelectedDose' value='" +diseaseDetail.doseName +"'/>" + diseaseDetail.doseName + "</td>";
    var quantityCell = "<td><input type='hidden' name='PatientDiseases[" + index + "].MedicineQuantity' value='" + diseaseDetail.quantity +"'/>" + diseaseDetail.quantity + "</td>";
    var noteCell = "<td><input type='hidden' name='PatientDiseases[" + index + "].Note' value='" +diseaseDetail.note +"'/>" + diseaseDetail.note + "</td>";
    var trItem = "<tr id='store_" + index + "'>"+diseaseCell + medicineCell+doseCell + quantityCell+noteCell + "</tr>";
    $("#tbl_disease").append(trItem);

});

function GetDiseaseDetail() {
    var diseaseId = $("#DiseaseId").val();
    var medicineId = $("#MedicineId").val();
    var diseaseName = $("#DiseaseId option:selected").text();
    var medicineName = $("#MedicineId option:selected").text();
    var doseName = $("#DoseId option:selected").text();
    var quantity = $("#Quantity").val();
    var note = $("#Note").val();
    if (medicineId == "") {
        return null;
    }
    var store =
    {
        medicineId: medicineId,
        diseaseId:diseaseId,
        medicineName: medicineName,
        diseaseName: diseaseName,
        doseName: doseName,
        quantity: quantity,
        note:note
    };
    return store;
};

$('#btn_showAllReport').click(function () {
    var aa = $('#PatientId').val();
    window.location.href = '/Report/ExportPatientTreatmentReport/' + aa;

});

