var DATA_MAP = {
    productGroups: [
        { "name": "WIndows", "id": 1 },
        { "name": "Android", "id": 2  },
        { "name": "All", "id": 3  },
    ],
    products: [
        { "name": "Windows10", "parentId": 1, "id": 11 },
        { "name": "Windows7", "parentId": 1, "id": 12 },
        { "name": "WindowsXP", "parentId": 1, "id": 13 },
        { "name": "Windows5", "parentId": 1, "id": 14 },
        { "name": "Windows3", "parentId": 1, "id": 15 },
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
    ],
    serviceCategory: [ "Game", "Program"]
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


        html = "";
        DATA_MAP.serviceCategory.forEach(function (serviceCategory) {
            html += `
            <div class='row' id="serviceCategoryDiv_${serviceCategory}">
                <div class="col-lg-2 border-right">
                    <input class="form-check-input" type="checkbox" value="${serviceCategory}" id="chk${serviceCategory}" name="chkSvcCategory">
                    <label class="form-check-label" for="chk${serviceCategory}">
                        ${serviceCategory}
                    </label>
                </div>
                <div class="col-lg-10 d-flex flex-row">
            `
            DATA_MAP.services.filter(svc => svc.category == serviceCategory).forEach(service => {
                html += `
                    <div class="ml-2">
                        <input type="checkbox" service-group="${serviceCategory}" data-group="${service.parentId}" value="${service.id}" id="chk${service.id}" name="chkSvc">
                        <label class="form-check-label" for="chk${service.id}">
                            ${service.name}
                        </label>
                    </div>
                `
            });

            html += "</div></div>";
        })
        $("#serviceDiv").html(html);

    },
    initEventHandler: function () {
        /** init event handler **/

        /*$("#productSelector > button").click(function () {
            $("#productSelector > button.active").not(this).removeClass("active");
            $(this).toggleClass("active");
        });*/

        $("#productSearchText").on("keyup", function (e) {
            const value = e.target.value;
            if (value.length > 1) {
                $('input:checkbox[name=productsChk]').each(function () {
                    if ($(this).parent().text().includes(value) &&
                        ($(this).attr("data-group") == CONTENTS_ONE.data.selectedProductGroup || CONTENTS_ONE.data.selectedProductGroup == '3')) {
                        $(this).parent().css("display", "block");
                    } else {
                        $(this).parent().css("display", "none");
                    }
                })
            } else {
                $('input:checkbox[name=productsChk]').each(function () {
                    if ($(this).attr("data-group") == CONTENTS_ONE.data.selectedProductGroup || CONTENTS_ONE.data.selectedProductGroup == '3') {
                        $(this).parent().css("display", "block");
                    } else {
                        $(this).parent().css("display", "none");
                    }
                })
            }

        });

        $('input[name=groupRdo]').on("change", function () {
            if ($('input[name=groupRdo]:checked').val() != undefined) {
                CONTENTS_ONE.data.selectedProductGroup = $('input[name=groupRdo]:checked').val();

                if (CONTENTS_ONE.data.selectedProductGroup != undefined) {
                    $('#collapseOne').collapse('show');
                } else {
                    $('#collapseOne').collapse('hide');
                }

                CONTENTS_ONE.applyProductView(CONTENTS_ONE.data.selectedProductGroup);
            }
        });

        $('input[name=productsChk]').on("change", function () {
            let arr = [];
            $("input:checkbox[name=productsChk]:checked").each(function () {
                arr.push($(this).val());
            });
            CONTENTS_ONE.data.selectedProducts = arr;

            if (arr.length > 0) {
                $('#collapseTwo').collapse('show');
            } else {
                $('#collapseTwo').collapse('hide');
            }

            CONTENTS_ONE.applyServiceView(CONTENTS_ONE.data.selectedProducts);
        });

        $('input[name=chkSvcCategory]').on("change", function () {
            const isChecked = $(this).prop("checked");

            // 하위 서비스 중 display: block 인 요소만 찾음
            $(this).parent().next().find('input:checkbox[name=chkSvc]:visible').each(function () {
                if (isChecked) {
                    $(this).prop("checked", true);
                } else {
                    $(this).prop("checked", false);
                }
            })

            $('input[name=chkSvc]').trigger('change'); // 하위 서비스 이벤트 트리거
        });

        $('input[name=chkSvc]').on("change", function () {
            let arr = [];
            $("input:checkbox[name=chkSvc]:checked").each(function () {
                arr.push($(this).val());
            });
            CONTENTS_ONE.data.selectedServices = arr;

            const service = $(this).attr("service-group");
            let isAllChecked = true;

            // 서비스 카테고리 checkbox 제어
            $('input:checkbox[name=chkSvc][service-group=' + service + ']:visible').each(function () {
                if ($(this).prop("checked") == false) {
                    isAllChecked = false;
                }
            });

            if (!isAllChecked) {
                $('input[name=chkSvcCategory][value=' + service + ']').prop("checked", false);
            } else {
                $('input[name=chkSvcCategory][value=' + service + ']').prop("checked", true);
            }
            // ------

            CONTENTS_ONE.applySelectedServiceView();
        });
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
    applyServiceView: function (selectedProducts) {
        $('input:checkbox[name=chkSvc]').each(function () {
            if (selectedProducts.includes($(this).attr("data-group"))) {
                $(this).parent().css("display", "block");
            } else {
                $(this).parent().css("display", "none");
            }
        })
    },
    applySelectedServiceView: function () {
        $("#selectedServiceDiv").empty();

        if (CONTENTS_ONE.data.selectedServices.length > 0) {
            // 선택된 서비스 이름 표시
            const selectedServiceNames = CONTENTS_ONE.data.selectedServices.map(serviceId => {
                return DATA_MAP.services.find(s => s.id == serviceId).name
            }).join(); // default separate: ,

            $("#selectedServiceDiv").append(selectedServiceNames);
            // ------

            $('#collapseThird').collapse('show');
        } else {
            $('#collapseThird').collapse('hide');
        }
    }
}

$(document).ready(function () {
    CONTENTS_ONE.init();
    CONTENTS_ONE.initEventHandler();
});