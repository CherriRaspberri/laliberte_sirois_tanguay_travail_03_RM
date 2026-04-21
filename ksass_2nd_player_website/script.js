//Olivier Laliberté - 2026

document.addEventListener('DOMContentLoaded', () => {
    //Selects every page in document
    const pages = document.querySelectorAll('.page');
    //current biggest z-index (priority)
    let topZIndex = 1;

    //Sets drag n drop feature
    pages.forEach(page => {
        let isDragging = false;

        let offsetX, offsetY;
        let prevX = 0;

        let activePage = null;

        //Checks for mouse hold on object
        //Sets object for mouse drag
        page.addEventListener('mousedown', (e) => {
            //Sets page target and only applies changes to target
            if (e.target.classList.contains('page')) {
                isDragging = true;
                activePage = e.target;

                //Lift page and straightens it (w/ transition)
                page.style.transform = `scale(1.2) rotate(0deg)`;
                page.style.transition = `transform 0.1s ease-out`;
                page.style.boxShadow = `0 20px 40px rgba(0,0,0,0.3)`;

                //Brings object to front
                topZIndex++;
                page.style.zIndex = topZIndex;

                //Calculates where the user clicked inside the page
                offsetX = e.clientX - page.offsetLeft;
                offsetY = e.clientY - page.offsetTop;
            }
        });

        //Checks if mouse is moving while holding object
        document.addEventListener('mousemove', (e) => {
            //If not holding, return
            if (!isDragging) return;

            //Calculates new pos
            const x = e.clientX - offsetX;
            const y = e.clientY - offsetY;

            //Creates velocity when dragged 
            let velocity = e.clientX - prevX;
            prevX = e.clientX;

            //Applies tilt relative to velocity
            let tilt = Math.max(Math.min(velocity * 0.5, 15), -15);

            //Applies new pos w/ tilt
            page.style.left = `${x}px`;
            page.style.top = `${y}px`;
            page.style.transform = `scale(1.1) rotate(${tilt}deg)`;
        });

        document.addEventListener('mouseup', () => {
            if (isDragging && activePage) {
                isDragging = false;
                activePage = null;

                //Drops page with random rotation
                const randomRotDrop = Math.floor(Math.random() * 20) - 10;
                page.style.transform = `scale(1.0) rotate(${randomRotDrop}deg)`;
                page.style.boxShadow = `0 4px 8px rgba(0,0,0,0.2)`;
            }
        });
    });
});

