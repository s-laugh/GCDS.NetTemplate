
const images = [
    "https://www.canada.ca/content/dam/canada/splash/sp-bg-1.jpg",
    "https://www.canada.ca/content/dam/canada/splash/sp-bg-2.jpg",
    "https://www.canada.ca/content/dam/canada/splash/sp-bg-3.jpg",
    "https://www.canada.ca/content/dam/canada/splash/sp-bg-4.jpg",
    "https://www.canada.ca/content/dam/canada/splash/sp-bg-5.jpg"
];

const randomImage = images[Math.floor(Math.random() * images.length)];

window.addEventListener('load', () => {
    document.body.style.backgroundImage = `url('${randomImage}')`;
});
