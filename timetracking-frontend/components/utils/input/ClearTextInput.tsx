import styles from "../../../styles/utils/input/ClearTextInput.module.css";
import TextInputProps from "../../../types/InputProps";
import TextInput from "./TextInput";

const ClearTextInput = (props: TextInputProps) => (
  <TextInput {...props} styles={styles} />
);

export default ClearTextInput;
