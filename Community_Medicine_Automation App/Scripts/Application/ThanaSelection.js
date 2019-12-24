//$(document).ready(function () {
//    $("#t_store").DataTable();
//});

$('#DistrictId').change(function () {
    var districtId = $("#DistricId").val();
    if (districtId == "") {
        $("#ThanaId").empty();
        var option = "<option value=''>Select </option>";
        $("#ThanaId").append(option);
        return;
    }

    $.ajax({
        type: "POST",
        url: "http://localhost:49267/HeadOffice/GetThanasByDistrict",
        datatype: "Json",
        data: { districtId: $('#DistrictId').val() },
        success: function (data) {
            $("#ThanaId").empty();
            $.each(data, function (index, value) {
                $('#ThanaId').append('<option value="' + value.Id + '">' + value.Name + '</option>');
            });
        }

    });
});


$('#ThanaId').change(function () {
    var thanaId = $("#ThanaId").val();
    if (thanaId == "") {
        $("#CenterId").empty();
        var option = "<option value=''>Select </option>";
        $("#CenterId").append(option);
        return;
    }

    $.ajax({
        type: "POST",
        url: "http://localhost:49267/HeadOffice/GetCentersByThana",
        datatype: "Json",
        data: { thanaId: $('#ThanaId').val() },
        success: function (data) {
            $("#CenterId").empty();
            $.each(data, function (index, value) {
                $('#CenterId').append('<option value="' + value.Id + '">' + value.Name + '</option>');
            });
        }

    });
});



$("#btn_store_add").click(function () {

    var storeDetail = GetStoreDetail();
    var index = $('#tbl_store tr').length;
    var medicineCell = "<td> <input type='hidden' name='StoreDetails[" + index + "].MedicineId' value='" + storeDetail.medicineId + "'/><input type='hidden' name='StoreDetails[" + index + "].Quantity' value='" + storeDetail.quantity + "' />" + storeDetail.medicineName + "</td>";
    var quantityCell = "<td>" + storeDetail.quantity + "</td>";
    var trItem = "<tr id='store_" + index + "'>" + medicineCell + quantityCell + " </tr>";
    $("#tbl_store").append(trItem);

});

function GetStoreDetail() {
    var medicineId = $("#MedicineId").val();
    var quantity = $("#Quantity").val();
    var medicineName = $("#MedicineId option:selected").text();
    if (medicineId == "") {
        return null;
    }
    var store =
    {
        medicineId: medicineId,
        quantity: quantity,
        medicineName: medicineName
    };
    return store;
};
