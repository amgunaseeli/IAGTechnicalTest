export function loadVehiclesModels(vehicleMake) {
  return dispatch => {
    return fetch(`http://localhost:8000/vehicle-checks/makes/${vehicleMake}`)
      .then(res => res.json())
      .then(vehicles => {
        dispatch(UpdateVehicleModels(vehicles.models));
      })
      .catch(console.log);
  };
}

export function UpdateVehicleModels(vehiclesModels) {
  return {
    type: 'UPDATE_VEHICLE_MODEL',
    vehiclesModels: vehiclesModels,
  };
}
