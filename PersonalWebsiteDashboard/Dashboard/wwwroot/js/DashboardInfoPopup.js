// Show/Hide Dashboard Info Modal Popup
function toggleDashboardInfoPopup() {
    if ($('.dashboardPopup').hasClass('modal-open'))
        $('.dashboardPopup').removeClass('modal-open');
    else
        $('.dashboardPopup').addClass('modal-open');

    if ($('.dashboardPopup').css('display') !== 'none') {
        $('.dashboardPopup').css('display', 'none');
        $('.overlay').css('display', 'none');
    }
    else {        
        $('.dashboardPopup').css('display', 'block');
        $('.overlay').css('display', 'block');
    }
}