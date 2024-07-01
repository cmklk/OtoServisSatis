const close_menu = document.querySelector('#menu_close');
const open_menu = document.querySelector('#hamburger_menu');
const menu_list = document.querySelector('.menu_list');

open_menu.addEventListener('click', function(){
    menu_list.classList.add('show');
})

close_menu.addEventListener('click', function(){
    menu_list.classList.remove('show');
})




window.sr = ScrollReveal();

sr.reveal('.animate-top', {
    origin: 'top',
    delay: 1000,
    duration: 1000,
    distance: '25rem'

});


sr.reveal('.animate-bottom', {
    origin: 'bottom',
    delay: 1000,
    duration: 1000,
    distance: '25rem'

});


