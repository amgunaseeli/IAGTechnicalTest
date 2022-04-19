import React from 'react';
import { connect } from 'react-redux';
import * as actionCreators from '../actions/Vehicle.js';
import Vehicle from '../component/Vehicle.js';
class VehicleContainer extends React.Component {
  render() {
    return <Vehicle handleChange={this.props.loadVehiclesModels} vehiclesModels={this.props.vehiclesModels}></Vehicle>;
  }
}

const mapStateToProps = state => {
  return state;
};

export default connect(mapStateToProps, actionCreators)(VehicleContainer);
