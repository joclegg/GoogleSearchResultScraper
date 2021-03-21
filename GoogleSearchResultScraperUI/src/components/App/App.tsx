import React from "react";
import SearchForm from "../SearchForm";
import useAppStyles from "./AppStyles";


const App = (): React.ReactElement => {
  const classes = useAppStyles();

  return (
    <div className={classes.root}>

    <SearchForm />
      {/* <Button className={classes.button} variant="contained" color="primary" onClick={incrementCounter}>
        Click me
      </Button>
      <Button className={classes.button} variant="contained" color="primary" onClick={getWinner}>
        Show winner
      </Button>
      <Typography className={classes.summary}>Button is clicked {store.counter} times.</Typography>
      <Typography>Random winner is {getFullName(store.winner)}.</Typography> */}
    </div>
  );
};

export default App;
