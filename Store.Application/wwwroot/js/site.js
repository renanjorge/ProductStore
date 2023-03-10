"use strict";

const productViewManager = function () {
    let $table;

    const $list = $("#lst-products");
    const $modal = $("#rgt-prd-modal");
    const $form = $("#frm-products");

    const $id = $("#frm-products #id");
    const $isActive = $("#frm-products #is-active");
    const $name = $("#frm-products #name");
    const $description = $("#frm-products #description");
    const $category = $("#frm-products #category");
    const $isPerishable = $("#frm-products #is-perishable");

    const saveProduct = function (data) {
        if ($form.validate().form()) {
            $.ajax({
                url: "/products",
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (result) {
                    $table.ajax.reload();
                    $modal.modal('hide');
                    $form[0].reset();
                }
            });
        }
    };

    const getEditProduct = function (id) {
        $.ajax({
            url: "/products/" + id,
            type: "GET",
            dataType: "json",
            success: function (result) {

                $id.val(result.id);
                $isActive.val(result.isActive);
                $name.val(result.name);
                $description.val(result.description);
                $category.val(result.categoryProductId);
                $isPerishable.prop("checked", result.isPerishable);

                $modal.modal("show");
            }
        });
    };

    // CRIAR CONFIRMAÇÃO DE EXCLUSÃO
    const deleteProduct = function (id) {
        $.ajax({
            type: "DELETE",
            url: "products/" + id,
            success: function () {
                $table.ajax.reload();
            }
        });
    };

    const resetForm = function () {
        $form[0].reset();
    };

    const datatableInit = function () {
        $table = $('#lst-products').DataTable({
            serverSide: true,
            processing: true,
            searching: false,
            ordering: false,
            ajax: {
                url: 'products/list',
                type: 'POST'
            },
            columns: [
                { "data": "id" },
                { "data": "name" },
                { "data": "description" },
                { "data": "categoryProductName" },
                { "data": "active" },
                { "data": "perishable" },
                {
                    "data": null,
                    "render": function (data, type, row) {
                        let btnUpdate = "<button type='button' class='btn-upt-prd btn btn-success btn-sm' data-id=" + data.id + ">Atualizar</button>";
                        let btnDelete = "<button type='button' class='btn-del-prd btn btn-danger btn-sm' data-id=" + data.id + ">Deletar</button>";

                        return btnUpdate + " " + btnDelete;
                    }
                }
            ],
            language: {
                url: '../lib/datatables/plug-ins/language/pt-BR.json'
            }
        });
    };

    $(document).ready(function () {
        datatableInit();

        $("#btn-sv-product").on("click", function () {
            let data = {
                Id: $id.val() === undefined || $id.val() === "" ? 0 : $id.val(),
                IsActive: $isActive.val() === "true" || $isActive.val() === "",
                Name: $name.val(),
                Description: $description.val(),
                CategoryProductId: $category.val(),
                IsPerishable: $isPerishable.prop("checked")
            };

            saveProduct(data);
        });

        $list.on("click", ".btn-upt-prd", function () {
            let id = $(this).data("id");
            getEditProduct(id);
        });

        $list.on("click", ".btn-del-prd", function () {
            let id = $(this).data("id");
            deleteProduct(id);
        });

        $("#rgt-prd-modal .close").on("click", function () {
            resetForm();
        });
    });

}();