import axios from "axios";

async function getDoughnutsFromApi() {
  const response = await axios.get(
    "https://reacttrainingbackend.azurewebsites.net/weatherforecast"
  );
  return response.data;
}

async function getResourcesFromApi() {
  const response = await axios.get(
    "https://reacttrainingbackend.azurewebsites.net/product"
  );

  return response.data;
}

async function getResourcesFromApi2() {
  const response = await axios.get(
    "https://reacttrainingbackend.azurewebsites.net/product/test2"
  );

  return response.data;
}

export { getDoughnutsFromApi, getResourcesFromApi, getResourcesFromApi2 };
