import {createStyles, makeStyles, Theme} from "@material-ui/core";

declare type classNames = "root";

export default makeStyles<Theme, Record<never, never>, classNames>((theme) =>
  createStyles({
    root: {
      margin: theme.spacing(2),
    }
  }),
);
