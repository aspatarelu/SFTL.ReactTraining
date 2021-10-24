import axios from 'axios'

async function getDoughnutsFromApi() {
  const response = await axios.get('https://localhost:44387/weatherForecast/get');
  return response.data;
}

export {
  getDoughnutsFromApi
}
