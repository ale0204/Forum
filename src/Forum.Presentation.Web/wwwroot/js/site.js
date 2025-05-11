const container = document.getElementById('notification-container');

function createNotification(message, notificationType='info') {
    const notif = document.createElement('div');
    notif.className = 'notification';
    if (notificationType === 'error')
        notif.classList.add('error');
    notif.textContent = message;

    // When clicked, immediately fade out and remove
    notif.addEventListener('click', () => {
        fadeOutAndRemove(notif);
    });

    container.appendChild(notif);

    // Auto fade out after 3 seconds
    setTimeout(() => {
        fadeOutAndRemove(notif);
    }, 5000);
}

function fadeOutAndRemove(element) {
    element.style.animation = 'fadeOut 0.6s ease forwards';
    element.addEventListener('animationend', () => {
        element.remove();
    });
}

