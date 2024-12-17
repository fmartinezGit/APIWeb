// Espera a que el documento se haya cargado completamente antes de ejecutar el código
document.addEventListener('DOMContentLoaded', () => {
    // Clave de la API de OpenWeather
    const apiKey = '1e064179bbb65fc53a3070a87e89da19';
    // Obtiene el botón de búsqueda por su ID
    const searchButton = document.getElementById('search-button');
    // Obtiene el campo de entrada de texto para la ciudad por su ID
    const cityInput = document.getElementById('city-input');

    // Añade un evento de clic al botón de búsqueda
    searchButton.addEventListener('click', () => {
        // Obtiene el valor del campo de entrada de texto
        const city = cityInput.value;
        // Verifica si se ingresó una ciudad
        if (city) {
            // URL para obtener el clima actual de la ciudad especificada
            const currentWeatherUrl = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}&units=metric&lang=es`;
            // URL para obtener el pronóstico de 5 días de la ciudad especificada
            const forecastUrl = `https://api.openweathermap.org/data/2.5/forecast?q=${city}&appid=${apiKey}&units=metric&lang=es`;

            // Realiza una solicitud fetch para obtener el clima actual
            fetch(currentWeatherUrl)
                .then(response => response.json()) // Convierte la respuesta a JSON
                .then(data => {
                    // Actualiza el contenido del HTML con los datos obtenidos
                    document.getElementById('city').textContent = data.name;
                    document.getElementById('temperature').textContent = `Temperatura: ${data.main.temp}°C`;
                    document.getElementById('description').textContent = `Descripción: ${data.weather[0].description}`;
                    // Obtiene el código del ícono del clima
                    const iconCode = data.weather[0].icon;
                    // Genera la URL del ícono del clima
                    const iconUrl = `https://openweathermap.org/img/wn/${iconCode}@2x.png`;
                    // Obtiene el elemento de la imagen del ícono del clima
                    const weatherIcon = document.getElementById('weather-icon');
                    // Actualiza la fuente de la imagen del ícono del clima
                    weatherIcon.src = iconUrl;
                    // Muestra la imagen del ícono del clima
                    weatherIcon.style.display = 'block';
                })
                .catch(error => console.error('Error al obtener los datos del clima:', error)); // Maneja cualquier error

            // Realiza una solicitud fetch para obtener el pronóstico del clima
            fetch(forecastUrl)
                .then(response => response.json()) // Convierte la respuesta a JSON
                .then(data => {
                    // Obtiene el contenedor del pronóstico
                    const forecastContainer = document.getElementById('forecast-container');
                    // Limpia el contenido previo del contenedor
                    forecastContainer.innerHTML = '';

                    // Filtra los datos del pronóstico para obtener un pronóstico por día
                    const forecastList = data.list.filter((item, index) => index % 8 === 0); 

                    // Itera sobre cada elemento del pronóstico filtrado
                    forecastList.forEach(item => {
                        // Crea un nuevo elemento div para cada día del pronóstico
                        const forecastDay = document.createElement('div');
                        // Añade la clase CSS al nuevo elemento
                        forecastDay.className = 'forecast-day';
                        // Obtiene el código del ícono del clima
                        const iconCode = item.weather[0].icon;
                        // Genera la URL del ícono del clima
                        const iconUrl = `https://openweathermap.org/img/wn/${iconCode}@2x.png`;
                        // Define el contenido HTML para el pronóstico del día
                        forecastDay.innerHTML = `
                            <p><strong>${new Date(item.dt_txt).toLocaleDateString('es-ES', { weekday: 'long', day: 'numeric', month: 'long' })}</strong></p>
                            <p>Temperatura: ${item.main.temp}°C</p>
                            <p>Descripción: ${item.weather[0].description}</p>
                            <img src="${iconUrl}" alt="Icono del clima">
                        `;
                        // Añade el nuevo elemento al contenedor del pronóstico
                        forecastContainer.appendChild(forecastDay);
                    });
                })
                .catch(error => console.error('Error al obtener el pronóstico:', error)); // Maneja cualquier error
        } else {
            // Muestra una alerta si no se ingresó ninguna ciudad
            alert('Por favor, ingresa el nombre de una ciudad.');
        }
    });
});
