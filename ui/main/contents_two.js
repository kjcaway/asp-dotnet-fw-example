var CONTENTS_TWO = {
    data: {},
    init: function () {
        /** init html **/
    },
    initEventHandler: function () {
        $('.parent i').on('click', function () {
            // click icon up/down
            const pid = $(this).parent().attr('id');
            
            if ($(this).hasClass('fa-chevron-up')) {
                // expand
                $(this).removeClass('fa-chevron-up');
                $(this).addClass('fa-chevron-down');

                $('.child').each(function () {
                    const parentId = $(this).attr('data-parent');
                    
                    if (pid == parentId) {
                        $(this).css('display', 'block');
                    }
                });
            } else {
                // constract
                $(this).removeClass('fa-chevron-down');
                $(this).addClass('fa-chevron-up');

                $('.child').each(function () {
                    const parentId = $(this).attr('data-parent');

                    if (pid == parentId) {
                        $(this).attr("style", "display: none !important");
                    }
                });
            }
        });
    }
}

$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });

    CONTENTS_TWO.init();
    CONTENTS_TWO.initEventHandler();
});