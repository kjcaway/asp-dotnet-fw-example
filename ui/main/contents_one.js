var DATA_MAP = {
    productGroups: [
        { "name": "WIndows", "id": 1 },
        { "name": "Android", "id": 2  },
        { "name": "All", "id": 3  },
    ],
    products: [
        { "name": "WIndows10", "parentId": 1, "id": 11 },
        { "name": "WIndows7", "parentId": 1, "id": 12 },
        { "name": "WIndowsXP", "parentId": 1, "id": 13 },
        { "name": "WIndows5", "parentId": 1, "id": 14 },
        { "name": "WIndows3", "parentId": 1, "id": 15 },
        { "name": "Android3", "parentId": 2, "id": 21 },
        { "name": "Android4", "parentId": 2, "id": 22 },
        { "name": "Android5", "parentId": 2, "id": 23 },
        { "name": "Android6", "parentId": 2, "id": 24 },
        { "name": "Android7", "parentId": 2, "id": 25 },
        { "name": "Android8", "parentId": 2, "id": 26 },
        { "name": "Android9", "parentId": 2, "id": 27 },
        { "name": "Android10", "parentId": 2, "id": 28 },
        { "name": "Android11", "parentId": 2, "id": 29 },
    ],
    services: [
        { "category": "Game", "name": "Starcraft", "parentId": 11, "id": 101 },
        { "category": "Game", "name": "Warcraft", "parentId": 11, "id": 102 },
        { "category": "Game", "name": "Counter Strike", "parentId": 11, "id": 103 },
        { "category": "Game", "name": "Minecraft", "parentId": 12, "id": 104 },
        { "category": "Game", "name": "FiFA", "parentId": 13, "id": 105 },
        { "category": "Game", "name": "NBA 20K", "parentId": 13, "id": 106 },
        { "category": "Game", "name": "CookieRun", "parentId": 21, "id": 107 },
        { "category": "Game", "name": "COC", "parentId": 28, "id": 108 },
        { "category": "Game", "name": "ClanOfWar", "parentId": 29, "id": 109 },
        { "category": "Game", "name": "삼국지", "parentId": 29, "id": 110 },
        { "category": "Game", "name": "프랑프랑", "parentId": 29, "id": 111 },
        { "category": "Program", "name": "굿닥터", "parentId": 11, "id": 201 },
        { "category": "Program", "name": "익스플로러", "parentId": 13, "id": 202 },
        { "category": "Program", "name": "크롬", "parentId": 13, "id": 203 },
        { "category": "Program", "name": "엣지", "parentId": 14, "id": 204 },
        { "category": "Program", "name": "V3 Security", "parentId": 12, "id": 205 },
        { "category": "Program", "name": "FireWall", "parentId": 28, "id": 206 },
        { "category": "Program", "name": "NetDoctor", "parentId": 29, "id": 207 },
    ]
}

var CONTENTS_ONE = {
    data: {},
    init: function () {
        /** init html **/
        let html = "";
        DATA_MAP.productGroups.forEach(function (group) {
            html += `
            <label class="btn btn-outline-primary">
                <input type="radio" name="groupRdo" id="grp_${group.id}" value="${group.id}">${group.name}
            </label>
            `
        })
        $("#productGroupDiv").html(html);

        html = "";
        DATA_MAP.products.forEach(function (product) {
            html += `
            <label class='tag form-check-label text-capitalize badge badge-secondary m-2' for='prd_${product.id}'>
                <input data-group='${product.parentId}' id='prd_${product.id}' value='${product.id}' name='productsChk' type='checkbox' class='form-check-input'>${product.name}
            </label>
            `
        })
        $("#productDiv").html(html);


       /* html = "";
        let html2 = "";
        DATA_MAP.services.forEach(function (service) {
            if (service.category == 'Game') {
                html += `
                <label class='tag form-check-label text-capitalize badge badge-success m-2' for='prd_${product.id}'>
                    <input data-group='${product.parentId}' id='prd_${product.id}' value='${product.id}' name='productsChk' type='checkbox' class='form-check-input'>${product.name}
                </label>
                `

            } else {
                html2 += `
                
                `
            }
        });
        $("#serviceDiv").html(html+html2);*/

    },
    initEventHandler: function () {
        /** init event handler **/

        /*$("#productSelector > button").click(function () {
            $("#productSelector > button.active").not(this).removeClass("active");
            $(this).toggleClass("active");
        });*/
        $('input[name=groupRdo]').on("change", function () {
            if ($('input[name=groupRdo]:checked').val() != undefined) {
                CONTENTS_ONE.data.selectedProductGroup = $('input[name=groupRdo]:checked').val();

                $('#collapseOne').collapse('show');

                CONTENTS_ONE.applyProductView(CONTENTS_ONE.data.selectedProductGroup);
            }
        })

        $('input[name=productsChk]').on("change", function () {
            let arr = [];
            $("input:checkbox[name=productsChk]:checked").each(function () {
                arr.push($(this).val());
            });
            CONTENTS_ONE.data.selectedProducts = arr;

            console.log(CONTENTS_ONE.data.selectedProducts)

            $('#collapseTwo').collapse('show');
        })
    },
    applyProductGroupView: function (data) {
        if (data.selectedProductGroup != undefined) {

        }
    },
    applyProductView: function (selectedProductGroup) {
        $('input:checkbox[name=productsChk]').each(function () {
            if ($(this).attr("data-group") == selectedProductGroup || selectedProductGroup == '3') {
                $(this).parent().css("display", "block");
            } else {
                $(this).parent().css("display", "none");
            }
        })
    },
}

$(document).ready(function () {
    CONTENTS_ONE.init();
    CONTENTS_ONE.initEventHandler();
});