let defaultState = {
  vehiclesModels: [{ name: '2 Eleven', yearsAvailable: 2 }],
};

const mainReducer = (state = defaultState, action) => {
  if (action.type === 'UPDATE_VEHICLE_MODEL') {
    return {
      ...state,
      vehiclesModels: action.vehiclesModels,
    };
  } else {
    return {
      ...state,
    };
  }
};

export default mainReducer;
