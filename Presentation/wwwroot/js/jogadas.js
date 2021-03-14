<script>
    function setJogadas() {
        $.ajax({
            type: 'POST',
            url: '@Url.Action("getSubPieces", "BillMaterial")', // call json method
            dataType: 'json',
            data: {
                pidpiece: $("#idpiece").val()
            },
            success: function (listasubpieces) {
                $.each(listasubpieces, function (i, listasubpieces) {
                    $("#idsubpiece").append('<option value="' + listasubpieces.Value + '">' +
                        listasubpieces.Text + '</option>');
                    i = i + 1;
                });
                $("#idsubpiece").change();
                if (Number(i) > 1) {
                    $("#idsubpiece").attr('required', true);
                }
            },
            error: function (ex, status) {
                alert(status + ' ' + ex);
            }
        });

    function getJogadas() {
        $.ajax({
            type: 'GET',
            url: '"/api/Print/GetHash"', // call json method
            dataType: 'json',
            data: {
                pidpiece: $("#idpiece").val()
            },
            success: function (listasubpieces) {
                $.each(listasubpieces, function (i, listasubpieces) {
                    $("#idsubpiece").append('<option value="' + listasubpieces.Value + '">' +
                        listasubpieces.Text + '</option>');
                    i = i + 1;
                });
                $("#idsubpiece").change();
                if (Number(i) > 1) {
                    $("#idsubpiece").attr('required', true);
                }
            },
            error: function (ex, status) {
                alert(status + ' ' + ex);
            }
        });
</script>