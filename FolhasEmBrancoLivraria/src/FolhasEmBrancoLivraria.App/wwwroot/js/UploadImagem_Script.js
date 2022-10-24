    $("#ImagemUpload").change(function () {
        $("#img_name").text(this.files[0].name);
    $("#img_name")[0].style.display = 'block';
        });

    $("#ImagemUpload").attr("data-val", "true");
    $("#ImagemUpload").attr("data-val-required", "Fill in the Image field.");