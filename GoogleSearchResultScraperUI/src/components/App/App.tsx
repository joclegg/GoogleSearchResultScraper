import React from "react";
import SearchForm from "../SearchForm";
import useAppStyles from "./AppStyles";


const App = (): React.ReactElement => {
  const classes = useAppStyles();

  return (
    <div className={classes.root}>
    <SearchForm />
    </div>
  );
};

export default App;
