let MAIN = {
    onAddCardClick: function (e) {
        const jqCard = $(`
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">제목</h5>
                    <h6 class="card-subtitle mb-2 text-muted">서브제목</h6>
                    <p class="card-text">블라블라</p>
                    <a href="#" class="card-link">Red</a>
                    <a href="#" class="card-link">Green</a>
                </div>
            </div>
        `);

        $(".card-deck").append(jqCard);
    }
};



$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });

    $("#addCardBtn").on("click", MAIN.onAddCardClick);
});