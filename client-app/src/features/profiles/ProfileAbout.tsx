import { observer } from "mobx-react-lite";
import { Tab, Grid, Header, Button } from "semantic-ui-react";
import ProfileEditForm from "./ProfileEditForm";
import { useStore } from "../../app/stores/store";
import { useState } from "react";

export default observer(function ProfileAbout() {
    const {profileStore} = useStore();
    const {isCurrentUser, profile} = profileStore;
    const [editMode, setEditMode] = useState(false);
    return (
        <Tab.Pane>
            <Grid>
                <Grid.Column width='16'>
                    <Header floated='left' icon='user' content={`About ${profile?.displayName}`} />
                    {isCurrentUser && (
                        <Button
                            floated='right'
                            basic
                            content={editMode ? 'Cancel' : 'Edit Profile'}
                            onClick={() => setEditMode(!editMode)}
                        />
                    )}
                </Grid.Column>
                <Grid.Column width='16'>
                    {editMode ? <ProfileEditForm setEditMode={setEditMode} /> :
                        <p style={{ whiteSpace: 'pre-wrap'}}>{profile?.bio}</p>}
                </Grid.Column>
            </Grid>
        </Tab.Pane>
    )
})