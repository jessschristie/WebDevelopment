function CreateMovie() {
    $.ajax({
        url: "/Movies/CreateMovie",
        type: 'POST',
    data: {
        Title: $('#Title').val(),
        WeekendRevenue: $('#WeekendRevenue').val(),
        GrossRevenue: $('#GrossRevenue').val(),
        Release: $('#Release').val(),
        Recommended: $('#Recommended').val()
    },
    success: function (result) {
        if (result.model.ValidationErrors != "") {
            $('#error').empty();
            $('#error').append(result.model.ValidationErrors.join("<br>"));
        } else {
            alert("Success");

        }
    }
    });
};

var detailsTemplate = kendo.template($("#template").html());

function showDetails(e) {
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#Details").data("kendoWindow");

    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();
}

function CreateNewMovie() {
    var wnds = $("#CreateWindow").data("kendoWindow");

    wnds.center().open();
}
