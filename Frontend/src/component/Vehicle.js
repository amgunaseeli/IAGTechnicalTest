import React, { Component } from 'react';

import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Container from '@material-ui/core/Container';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Icon from '@material-ui/core/Icon';
import Grid from '@material-ui/core/Grid';
import Header from '../component/Header';
import Paper from '@material-ui/core/Paper';
import './App.css';

export default class Vehicle extends Component {
  constructor(props) {
    super(props);
    this.state = {
      models: this.props.vehiclesModels,
    };
  }

  render = () => {
    return (
      <Container maxwidthxl="true">
        <div>
          <Header />
          <br />
          <Grid container direction="row" alignItems="center">
            <Grid container direction="row" alignItems="center" item xs={2}>
              <TextField label="Vehicle Make" name="vehicleMake" inputProps={{ ref: vm => (this.vehicleMake = vm) }} p={5} required />
            </Grid>
            <Grid container direction="row" alignItems="center" item xs={2}>
              <Button
                variant="outlined"
                color="primary"
                onClick={() => {
                  if (this.vehicleMake.value.length > 0) this.props.handleChange(this.vehicleMake.value);
                }}
                endIcon={<Icon>search</Icon>}
              >
                Search
              </Button>
            </Grid>
          </Grid>
          <br />
          <Paper>
            <Table aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell>Name</TableCell>
                  <TableCell>Years Available</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {this.props.vehiclesModels.map(model => (
                  <TableRow key={model.name + model.yearsAvailable}>
                    <TableCell component="th" scope="row">
                      {model.name}
                    </TableCell>
                    <TableCell>{model.yearsAvailable}</TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </Paper>
        </div>
      </Container>
    );
  };
}
